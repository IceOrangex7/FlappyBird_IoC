using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class BirdMediator : EventMediator {

	[Inject]
	public BirdView _birdView{get;set;}

	/// <summary>
	/// 开始调用
	/// </summary>
	public override void OnRegister ()
	{
		dispatcher.AddListener (Events.Update_ScoreUI,OnUpdate);
		_birdView.dispacher.AddListener (Events.Score_View_Mediator,OnAddScore);
		_birdView.InitView (); 
	}

	/// <summary>
	/// 结束调用
	/// </summary>
	public override void OnRemove ()
	{
		dispatcher.RemoveListener (Events.Update_ScoreUI,OnUpdate);
		_birdView.dispacher.RemoveListener (Events.Score_View_Mediator,OnAddScore);
	}

	public void OnUpdate(IEvent evt){
		int score = (int) evt.data;
		_birdView.UpdateScore (score);
	}

	public void OnAddScore(){
		dispatcher.Dispatch (Events.Add_Sorce);	
	}
}
