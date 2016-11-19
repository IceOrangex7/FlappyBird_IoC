using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class GameRoot : ContextView {
	void Awake(){
		this.context = new GameContext (this,true);
		context.Start ();
	}


}
