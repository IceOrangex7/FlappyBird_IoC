using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class ResetMediator : EventMediator{
	[Inject]
	public ResetView _resetView{get;set;}

	public override void OnRegister ()
	{
		_resetView.dispatcher.AddListener (ResetEvents.View_Mediator,OnReset);
		_resetView.InitView ();
	}

	public override void OnRemove ()
	{
		_resetView.dispatcher.RemoveListener (ResetEvents.View_Mediator,OnReset);
	}

	void OnReset(){
		_resetView.UpdateReset ();
		_resetView._reset.onClick.AddListener (delegate {
			dispatcher.Dispatch (ResetEvents.Command);	
		});
	}
}
