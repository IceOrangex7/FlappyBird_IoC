using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Text;

public class BirdView : View {
	
	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject ContextView{ get; set;}

	[Inject]
	public IEventDispatcher dispacher{get;set;}

	private ExitDetector exitDetector;

	private Text _score;

	/// <summary>
	/// 初始化方法
	/// </summary>
	public void InitView(){
		_score = ContextView.transform.Find ("Canvas/Score").GetComponent<Text>();	
		_score.text = "当前分数:0";
		exitDetector = ContextView.transform.Find ("Bird").GetComponent<ExitDetector> ();
	}
	protected override void Start ()
	{
		base.Start ();
		exitDetector.dispacher.AddListener (Events.GetScore_View,OnGetScore);
	}
	/// <summary>
	/// 更新UI方法
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateScore(int score){
		_score.text = "当前分数:" + score.ToString ();
	}

	public void OnGetScore(){
		dispacher.Dispatch (Events.Score_View_Mediator);
	}
}
