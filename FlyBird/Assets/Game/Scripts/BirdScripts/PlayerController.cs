using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	
	Rigidbody2D _rb;
	[SerializeField]
	float _force;

	float _add_force;

	void Awake(){
		_rb = GetComponent<Rigidbody2D> ();
	}
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetMouseButtonDown(0)) {
		_rb.AddForce (new Vector2(0,_force));
		}
		#elif UNITY_EDITOR_OSX
			if (Input.GetKeyDown (KeyCode.Space)) {
			_rb.AddForce (new Vector2(0,_force));
			}
		#elif UNITY_IOS
		if (Input.GetMouseButtonDown(0)) {
			_rb.AddForce (new Vector2(0,_force));
			}
		#elif UNITY_STANDALONE_WIN
			if (Input.GetKeyDown (KeyCode.Space)) {
			_rb.AddForce (new Vector2(0,_force));
			}
		#endif    
	}
}
