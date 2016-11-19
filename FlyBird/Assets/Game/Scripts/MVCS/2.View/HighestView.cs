using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class HighestView : View {

	[Inject]
	public IEventDispatcher dispatcher{get;set;}

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{get;set;}

	Text _highest_sorce;

	public void InitView(){
		_highest_sorce = ContextView.transform.Find ("Canvas/Highest_Score").GetComponent<Text>();
		_highest_sorce.text = "";
	}

	/// <summary>
	/// 更新UI方法
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateHighestScore(int score){
		_highest_sorce.text = "历史最高分:" + score.ToString ();
	}

}
