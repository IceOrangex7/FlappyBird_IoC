using UnityEngine;
using System.Collections;

public class FireTest : MonoBehaviour {

	[SerializeField]
	EllipsoidParticleEmitter _fire;
	bool _isMin = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUILayout.Button("11111")) {
			StopAllCoroutines (); 
			_isMin = !_isMin;
			StartCoroutine (Change());	
		}
	}

	IEnumerator Change(){
		if (!_isMin) {
			while (_fire.minSize > 0.4f) {
				_fire.minSize -= Time.deltaTime / 5;
				_fire.maxSize -= Time.deltaTime / 5;
				yield return 0;
			}
			yield break;
		} else {
			while (_fire.minSize < 0.6f) {
				_fire.minSize += Time.deltaTime / 5;
				_fire.maxSize += Time.deltaTime / 5;
				yield return 0;
			}
			yield break;
		}
	}
}
