using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class StartMediator : EventMediator{
	[Inject]
	public StartView _startView{get;set;}

	public override void OnRegister ()
	{
		dispatcher.AddListener (StartEvents.Command_Mediator,OnStart);
		_startView.InitView ();
	}

	public override void OnRemove ()
	{
	    dispatcher.RemoveListener (StartEvents.Command_Mediator,OnStart);
	}

	void OnStart(){
		StartCoroutine (StartWait());
	}
	IEnumerator StartWait(){
		int index = 3;
		while (index >= 0) {
			Sprite s = Resources.Load<Sprite> ("Texture/Start0" + index);
			_startView.UpdateStart (s);
			yield return new WaitForSeconds (0.1f);
			index--;
		}
		_startView.UpdateStart ();
		dispatcher.Dispatch (BackMoveEvents.Command);
	}
}