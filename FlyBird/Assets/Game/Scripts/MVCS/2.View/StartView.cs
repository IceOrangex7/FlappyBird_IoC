using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;
using UnityEngine.UI;

public class StartView : View {

	[Inject]
	public IEventDispatcher dispatcher{get;set;}

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{get;set;}
	[HideInInspector]
	public Image _start;

	public void InitView(){
		_start = ContextView.transform.Find ("Canvas/StartWait").GetComponent<Image>();
	}
	/// <summary>
	/// 更新UI方法
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateStart(Sprite s){
		_start.GetComponent<CanvasGroup> ().alpha = 1;
		_start.sprite = s;
	}
	public void UpdateStart(){
		_start.GetComponent<CanvasGroup> ().alpha = 0;
	}
}
