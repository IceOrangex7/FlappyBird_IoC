using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class ResetView :  View {

	[Inject]
	public IEventDispatcher dispatcher{get;set;}

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{get;set;}
	[HideInInspector]
	private ExitDetector exitDetector;
	[HideInInspector]
	public Button _reset;

	public void InitView(){
		_reset = ContextView.transform.Find ("Canvas/Reset").GetComponent<Button>();
		exitDetector = ContextView.transform.Find ("Bird").GetComponent<ExitDetector> ();
	}
	protected override void Start ()
	{
		base.Start ();
		exitDetector.dispacher.AddListener (ResetEvents.View,OnReset);
	}
	/// <summary>
	/// 更新UI方法
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateReset(){
		_reset.GetComponent<CanvasGroup> ().alpha = 1;
	}
	public void OnReset(){
		dispatcher.Dispatch (ResetEvents.View_Mediator);
	}
}
