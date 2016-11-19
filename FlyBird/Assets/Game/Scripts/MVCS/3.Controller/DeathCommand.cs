using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using UnityEngine.SceneManagement;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class DeathCommand : Command {

	public override void Execute ()
	{
		Time.timeScale = 0;
	}

}
public class ResetCommand : Command {

	public override void Execute ()
	{
		SceneManager.LoadScene (1);
	}

}
