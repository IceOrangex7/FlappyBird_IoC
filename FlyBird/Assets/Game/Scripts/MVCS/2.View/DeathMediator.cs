using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class DeathMediator : EventMediator{
	[Inject]
	public DeathView _deathView{get;set;}

	public override void OnRegister ()
	{
		_deathView.dispatcher.AddListener (Events.Death_View_Mediator,OnDeath);
		_deathView.InitView ();
	}

	public override void OnRemove ()
	{
		_deathView.dispatcher.RemoveListener (Events.Death_View_Mediator,OnDeath);
	}

	void OnDeath(){
		_deathView.UpdateDeath ();
		dispatcher.Dispatch (Events.Death_Command);	
	}

}
