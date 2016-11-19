using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class ExitDetector : View {
	[Inject]
	public IEventDispatcher dispacher{get;set;}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("pipe")) {
			dispacher.Dispatch (Events.GetScore_View);
		}
	}
	public void OnCollisionEnter2D(Collision2D other){
		dispacher.Dispatch (Events.Death_View);
		dispacher.Dispatch (ResetEvents.View);
	}
}
