using UnityEngine;
using System.Collections;

public class PipesRandom : MonoBehaviour {

	[SerializeField]
	float _downY;
	[SerializeField]
	float _upY;

	void OnEnable(){
		RandomY ();
	}


	void RandomY(){
		float y = Random.Range (_downY,_upY);
		transform.position = new Vector2 (transform.position.x,y);
	}
}
