using UnityEngine;
using System.Collections;

public enum Events{
	Highest_Score,
	Highest_Score_Over,
	Update_Highest_ScoreUI,
	Update_ScoreUI,
	GetScore_View,
	Score_View_Mediator,
	Add_Sorce,
	Death_View,
	Death_Command,
	Death_View_Mediator
}

public enum ResetEvents{
	View,
	View_Mediator,
	Command
}
public enum StartEvents{
	Command_Mediator,
	Command
}
public enum BackMoveEvents{
	Command_Mediator,
	Command
}