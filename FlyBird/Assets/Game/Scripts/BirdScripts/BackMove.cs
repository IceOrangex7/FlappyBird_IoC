using UnityEngine;
using System.Collections;

public class BackMove : MonoBehaviour {

	Transform[] _scripts;
	[SerializeField]
	float _speed;
	[SerializeField]
	Vector3 _start;
	[SerializeField]
	Vector3 _end;

	void Awake(){
		_scripts = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			_scripts [i] = transform.GetChild (i);
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < _scripts.Length; i++) {
			_scripts[i].Translate (Vector3.right * Time.deltaTime * -_speed,Space.Self);
			if (_scripts[i].position.x <= _end.x) {
				_scripts[i].position = new Vector3 (_start.x,_scripts[i].position.y,0);
				_scripts [i].gameObject.SetActive (false);
				_scripts [i].gameObject.SetActive (true);
			}
		}
	}

}
