using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

public class HighestSorceCommand : EventCommand {

	[Inject]
	public IBirdService BirdService{get;set;}
	[Inject]
	public IHighestModel HighestModel{ get; set;}

	public override void Execute ()
	{
		BirdService.Request ("//");
		BirdService.dispatcher.AddListener (Events.Highest_Score_Over,OnComplete);
	}

	void OnComplete(IEvent evt){
		BirdService.dispatcher.RemoveListener (Events.Highest_Score_Over,OnComplete);
		int score = (int)evt.data;
		//更新UI
		dispatcher.Dispatch(Events.Update_Highest_ScoreUI,score);
		//保存数据
		HighestModel.Data = score;
	}
}
