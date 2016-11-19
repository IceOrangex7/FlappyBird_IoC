
/*
	脚本名称 : PoolManager.cs

	创建人 : #AuthorName#

	创建时间 : #CreateTime#

*/

using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class PoolManager : MonoBehaviour {
	private static PoolManager _instance;
	public static PoolManager Instance{get{ return _instance; } }

	public string ResourcesDir="PoolPrefabs";

	void Awake(){
		_instance=this;
		LoadPools ();
	}

	/// <summary>
	/// 注册方法
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="count">Count.</param>
	public void Register(string name,int count){
		string path = ResourcesDir + "/" + name;
		GameObject go = Resources.Load <GameObject>(path);
		if (go==null) 
			return;
		ObjectPool pool = new ObjectPool (go,name,count);
		poolDict.Add (name,pool);
		Debug.Log (name +"对象池注册成功,最大数量为:" + count);
	}

	public void LoadPools(){
		string[] pools = File.ReadAllLines (Consts.PoolsPath);
		for (int i = 0; i < pools.Length; i++) {
			if (pools [i] == "")
				return;

			string[] infos = pools [i].Split (',');
			string name = infos [0];
			int count = Convert.ToInt32 (infos [1]);
			Register (name,count);
		}
	}

	/// <summary>
	/// 管理所有对象池的字典
	/// key - 对象池名称
	/// value - 对象池
	/// </summary>
	public Dictionary<string ,ObjectPool> poolDict = new Dictionary<string, ObjectPool>();

	/// <summary>
	/// 获取指定对象池中的对象
	/// </summary>
	/// <returns>The objcet.</returns>
	/// <param name="poolName">Pool name.</param>
	public GameObject GetObjcet(string poolName){
		if (!poolDict.ContainsKey (poolName)) {
			Debug.LogError ("没有该对象池:" + poolName);
			return null;
		}
		ObjectPool pool = poolDict [poolName];
		return pool.GetObject();
	}

	/// <summary>
	/// 隐藏指定游戏物体
	/// </summary>
	/// <param name="go"> 指定游戏物体 </param>
	public void HideObject(GameObject go){
		ObjectPool pool = null;
		foreach (ObjectPool p in poolDict.Values) {
			if (p.PrefabList.Contains (go)) {
				pool = p;
				break;
			}
		}
		if (pool != null) 
			pool.HideObject (go);
		
	}

	/// <summary>
	/// 隐藏指定对象池所有物体
	/// </summary>
	/// <param name="poolName"> 对象池 </param>
	public void HideAllObject(string poolName){
		if (!poolDict.ContainsKey (poolName)) {
			Debug.LogError ("没有该对象池:" + poolName);
			return;
		}
		ObjectPool pool = poolDict [poolName];
		pool.HideAllObject ();
	}

	public void DestroyAllObject(){
		foreach (var key in poolDict.Keys) {
			poolDict [key].DestroyAllObject ();
		}
	}
}
