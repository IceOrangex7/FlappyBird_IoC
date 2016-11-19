using UnityEngine;
using System.Collections;

public class ScoreModel :IBirdModel{
	#region IBirdModel implementation
	public int Data {
		get {
			return _data;
		}
		set {
			_data =value;
			Debug.Log ("当前分数存储成功:" + Data.ToString());
		}
	}
	#endregion
	private int _data=0;
}
public class HighestModel :IHighestModel{
	#region IBirdModel implementation
	public int Data {
		get {
			return PlayerPrefs.GetInt ("HighestData");
		}
		set {
			PlayerPrefs.SetInt ("HighestData",value);
		}
	}
	#endregion

}