using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class BirdService : IBirdService {
	
	/// <summary>
	/// 任务派发器
	/// </summary>
	/// <value>The dispatcher.</value>
	[Inject]
	public IEventDispatcher dispatcher { get; set;}
	/// <summary>
	/// 获取游戏根节点
	/// </summary>
	/// <value>The context view.</value>
	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{ get; set;}
	/// <summary>
	/// 服务器地址
	/// </summary>
	/// <value>The UR.</value>
	public string URL { get; set;}
	/// <summary>
	/// 向服务器发送请求
	/// </summary>
	/// <param name="url">URL.</param>
	public void Request (string url)
	{
		this.URL = url;
		MonoBehaviour root = ContextView.GetComponent<GameRoot>();
		root.StartCoroutine (GetMsg());
	}

	private IEnumerator GetMsg(){
		//等待服务器数据
		yield return 0;
		//派发命令
		dispatcher.Dispatch (Events.Highest_Score_Over,PlayerPrefs.GetInt ("HighestData",0));
	}
}
