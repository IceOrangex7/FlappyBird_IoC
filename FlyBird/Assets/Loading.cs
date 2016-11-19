using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		Time.timeScale = 1;
		StartCoroutine (StartLoading());
	}

	IEnumerator StartLoading(){
		yield return new WaitForSeconds (2f);
		Debug.Log ("111");
		SceneManager.LoadScene ("Main");
	}
}
