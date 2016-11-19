
/*
	脚本名称 : ObjectPool.cs

	创建人 : #AuthorName#

	创建时间 : #CreateTime#

*/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 单个对象池
/// </summary>
public class ObjectPool  {
	//对象池的对象
	public GameObject Prefab{get;private set;}
	//对象池的名字
	public string Name{get;private set;}
	//对象池最大的数量
	public int MaxCount{ get; private set;}
	//对象池对象的集合
	public List<GameObject> PrefabList;

	public ObjectPool (GameObject prefab,string name,int maxCount)
	{
		PrefabList = new List<GameObject> ();
		this.Name = name;
		this.Prefab = prefab;
		this.MaxCount = maxCount;
	}

	/// <summary>
	/// 从对象池获取对象的方法
	/// </summary>
	/// <returns> 获取到的游戏对象 </returns>
	public GameObject GetObject(){
		GameObject go = null;
		for (int i = 0; i < PrefabList.Count; i++) {
			if (!PrefabList[i].activeSelf) {
				go = PrefabList [i];
				go.SetActive (true);
				break;
			}
		}
		if (go == null) {
			if (PrefabList.Count >= MaxCount) {
				GameObject.Destroy (PrefabList[0]);
				PrefabList.RemoveAt (0);
			}
			go = GameObject.Instantiate <GameObject> (Prefab);
			PrefabList.Add (go);
		}
		//调用一个初始化的方法
		go.SendMessage("BeforeGetObject",SendMessageOptions.DontRequireReceiver);
		return go;
	}
		
	/// <summary>
	/// 隐藏对象池指定游戏对象
	/// </summary>
	/// <param name="go"> 指定的游戏对象 </param>
	public void HideObject(GameObject go){
		if (PrefabList.Contains (go)) {
			go.SetActive (false);
			go.SendMessage("BeforeHideObject",SendMessageOptions.DontRequireReceiver);
		}
	}

	/// <summary>
	/// 隐藏对象池所有游戏对象
	/// </summary>
	public void HideAllObject(){
		for (int i = 0; i < PrefabList.Count; i++) {
			if (PrefabList [i].activeSelf)
				HideObject (PrefabList [i]);
		}
	}

	public void DestroyAllObject(){
		PrefabList = new List<GameObject> ();
	}
}
