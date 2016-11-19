using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class BackMediator : EventMediator{
	[Inject]
	public BackView _backView{get;set;}

	public override void OnRegister ()
	{
		dispatcher.AddListener (BackMoveEvents.Command_Mediator,OnStart);
		_backView.InitView ();
	}

	public override void OnRemove ()
	{
		dispatcher.RemoveListener (BackMoveEvents.Command_Mediator,OnStart);
	}

	void OnStart(){
		_backView.UpdateStart ();
	}
}
