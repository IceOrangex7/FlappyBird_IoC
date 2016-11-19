using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;
using UnityEngine.UI;

public class BackView : View {

	[Inject]
	public IEventDispatcher dispatcher{get;set;}

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{get;set;}

	private BackMove[] _backsMove;

	private PipesRandom[] _pipesRandom;

	private Rigidbody2D _bird;

	public void InitView(){
		_backsMove = ContextView.transform.Find ("Background").GetComponentsInChildren<BackMove>();
		_pipesRandom = ContextView.transform.Find ("Background/bg_pipes").GetComponentsInChildren<PipesRandom>();
		_bird = ContextView.transform.Find ("Bird").GetComponent<Rigidbody2D>();
	}

	/// <summary>
	/// 更新UI方法
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateStart(){
		for (int i = 0; i < _backsMove.Length; i++) {
			_backsMove [i].enabled = true;
		}
		for (int i = 0; i < _pipesRandom.Length; i++) {
			_pipesRandom [i].enabled = true;
		}
		_bird.isKinematic = false;
	}
}

