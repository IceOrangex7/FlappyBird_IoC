using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class DeathView : View {

	[Inject]
	public IEventDispatcher dispatcher{get;set;}

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{get;set;}


	private ExitDetector exitDetector;

	CanvasGroup _death;

	public void InitView(){
		_death = ContextView.transform.Find ("Canvas/Death").GetComponent<CanvasGroup>();
		exitDetector = ContextView.transform.Find ("Bird").GetComponent<ExitDetector> ();
	}
	protected override void Start ()
	{
		base.Start ();
		exitDetector.dispacher.AddListener (Events.Death_View,OnDeath);
	}
	/// <summary>
	/// 更新UI方法
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateDeath(){
		_death.alpha = 1;
	}
	public void OnDeath(){
		dispatcher.Dispatch (Events.Death_View_Mediator);
	}
}
