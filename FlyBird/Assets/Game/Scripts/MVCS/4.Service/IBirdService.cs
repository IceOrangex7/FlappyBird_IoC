using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

public interface IBirdService {
	/// <summary>
	/// 服务器地址
	/// </summary>
	/// <value>The UR.</value>
	string URL{get;set;}
	/// <summary>
	/// 任务派发器
	/// </summary>
	/// <value>The dispatcher.</value>
	IEventDispatcher dispatcher{ get; set;}
	/// <summary>
	/// 向服务器发送请求
	/// </summary>
	/// <param name="url">URL.</param>
	void Request(string url);
}
