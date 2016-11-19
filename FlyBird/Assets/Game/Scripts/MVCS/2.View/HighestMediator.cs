using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class HighestMediator : EventMediator {

	[Inject]
	public HighestView _highest{get;set;}

	public override void OnRegister ()
	{
		dispatcher.AddListener (Events.Update_Highest_ScoreUI,OnUpdate);
		_highest.InitView ();
	}

	public override void OnRemove ()
	{
		dispatcher.RemoveListener (Events.Update_Highest_ScoreUI,OnUpdate);
	}

	public void OnUpdate(IEvent evt){
		int score = (int) evt.data;
		_highest.UpdateHighestScore (score);
	}
}
