using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class AddSorceCommand : EventCommand {

	[Inject]
	public IBirdModel ScoreModel{ get; set;}
	[Inject]
	public IHighestModel HighestModel{ get; set;}

	public override void Execute ()
	{
		ScoreModel.Data++;
		dispatcher.Dispatch (Events.Update_ScoreUI,ScoreModel.Data);
		if (ScoreModel.Data > HighestModel.Data) {
			HighestModel.Data = ScoreModel.Data;
			dispatcher.Dispatch (Events.Update_Highest_ScoreUI,HighestModel.Data);
		}
	}
}
