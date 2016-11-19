using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class GameContext : MVCSContext {

	public GameContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping){}

	/// <summary>
	/// 实现绑定
	/// </summary>
	protected override void mapBindings ()
	{
		commandBinder.Bind (ContextEvent.START).To<StartCommand> ().Once();
		mapModel ();
		mapController ();
		mapView ();
	}

	/// <summary>
	/// 映射模型
	/// </summary>
	private void mapModel(){
		//InjectionBinder
		injectionBinder.Bind<IBirdService>().To<BirdService>().ToSingleton();
		injectionBinder.Bind<IBirdModel> ().To<ScoreModel> ().ToSingleton ();
		injectionBinder.Bind<IHighestModel> ().To<HighestModel> ().ToSingleton ();
	}

	/// <summary>
	/// 映射视图
	/// </summary>
	private void mapView(){
		//MediationBinder
		mediationBinder.Bind<BirdView>().To<BirdMediator>();
		mediationBinder.Bind<HighestView> ().To<HighestMediator> ();
		mediationBinder.Bind<DeathView> ().To<DeathMediator> ();
		mediationBinder.Bind<ResetView> ().To<ResetMediator> ();
		mediationBinder.Bind<StartView> ().To<StartMediator> ();
		mediationBinder.Bind<BackView> ().To<BackMediator> ();
	}

	/// <summary>
	/// 映射控制器
	/// </summary>
	private void mapController(){
		//CommandBinder
		commandBinder.Bind(Events.Highest_Score).To<HighestSorceCommand>();
		commandBinder.Bind (Events.Add_Sorce).To<AddSorceCommand> ();
		commandBinder.Bind (Events.Death_Command).To<DeathCommand> ();
		commandBinder.Bind (ResetEvents.Command).To<ResetCommand> ();
		commandBinder.Bind (StartEvents.Command).To<StartWaitCommand> ();
		commandBinder.Bind (BackMoveEvents.Command).To<BackMoveCommand> ();
	}
}
