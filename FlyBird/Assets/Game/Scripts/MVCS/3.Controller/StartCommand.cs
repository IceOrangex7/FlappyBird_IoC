using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class StartCommand : Command {

	[Inject(ContextKeys.CROSS_CONTEXT_DISPATCHER)]
	public IEventDispatcher dispatcher{get;set;}

	public override void Execute ()
	{
		Debug.Log ("游戏开始");
		dispatcher.Dispatch (Events.Highest_Score);
		dispatcher.Dispatch (StartEvents.Command);
	}
}

public class StartWaitCommand : Command {

	[Inject(ContextKeys.CROSS_CONTEXT_DISPATCHER)]
	public IEventDispatcher dispatcher{get;set;}

	public override void Execute ()
	{
		dispatcher.Dispatch(StartEvents.Command_Mediator);
	}
}
public class BackMoveCommand : Command {

	[Inject(ContextKeys.CROSS_CONTEXT_DISPATCHER)]
	public IEventDispatcher dispatcher{get;set;}

	public override void Execute ()
	{
		dispatcher.Dispatch (BackMoveEvents.Command_Mediator);
	}
}