
/*
	脚本名称 : PoolEditor.cs

	创建人 : #AuthorName#

	创建时间 : #CreateTime#

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;


public class PoolEditor : EditorWindow {

	[MenuItem("Manager/RegisterPool")]
	static void CreatWindow(){
		PoolEditor window = EditorWindow.GetWindow<PoolEditor> ("对象池管理");
		window.Show ();
	}

	private string objectName;
	private string maxCount;
	private Dictionary<string,string> pools_dic = new Dictionary<string, string> ();
	private List<string> names=new List<string>();
	private List<string> counts=new List<string>();
	private bool IsChange=false;

	void OnGUI(){
		objectName = EditorGUILayout.TextField ("物体名称",objectName);
		maxCount = EditorGUILayout.TextField ("最大数量",maxCount);
		if (GUILayout.Button ("注册对象池")) {
			if (!pools_dic.ContainsKey (objectName)) {
				FileInfo f = new FileInfo (Consts.PoolsPath);
				StreamWriter sw = f.AppendText ();
				sw.WriteLine (objectName + "," + maxCount);
				sw.Dispose ();
				sw.Close ();
				EditorUtility.DisplayDialog ("注册对象池", "注册成功", "确定");
			} else {
				EditorUtility.DisplayDialog ("注册对象池", "已有该对象池", "确定");
			}
		}

		if (File.Exists (Consts.PoolsPath)) {
			pools_dic.Clear ();
			string[] pools = File.ReadAllLines (Consts.PoolsPath);
			if (pools.Length > 0) {
				for (int i = 0; i < pools.Length; i++) {
					if (pools [i] == "")
						return;
					
					string[] pool = pools [i].Split (',');
					if (!pools_dic.ContainsKey(pool [0])) {
						pools_dic.Add (pool [0], pool [1]);
					}
				}
			}
		}

		if (pools_dic.Count > 0) {
			names = new List<string> ();
			counts = new List<string> ();
			foreach (var name in pools_dic.Keys) {
				names.Add (name);
				counts.Add (pools_dic[name]);
			}	
			for (int i = 0; i < names.Count; i++) {
				string tempname = names [i];
				string tempcount = counts [i];
				names [i] = EditorGUILayout.TextField ("物体名称", names [i]);
				counts [i] = EditorGUILayout.TextField ("物体数量", counts [i]);

				if (tempname != names [i] || tempcount != counts [i]) {
					IsChange = true;
				}
			}
		}
		if (IsChange) {
			File.Delete (Consts.PoolsPath);
			AssetDatabase.Refresh ();
			for (int i = 0; i < names.Count; i++) {
				FileInfo f = new FileInfo (Consts.PoolsPath);
				StreamWriter sw = f.AppendText ();
				sw.WriteLine (names[i] + "," + counts[i]);
				sw.Dispose ();
				sw.Close ();
			}
			IsChange = false;
		}


		if (GUILayout.Button ("清空对象池")) {
			if (!File.Exists (Consts.PoolsPath)) {
				EditorUtility.DisplayDialog ("没有对象池", "清空失败", "确定");
			} else {
				File.Delete (Consts.PoolsPath);
				pools_dic.Clear ();
				AssetDatabase.Refresh ();
				EditorUtility.DisplayDialog ("清空对象池", "清空成功", "确定");
			}
		}
	}

}
