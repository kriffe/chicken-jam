using UnityEngine;
using System.Collections;

public class MotherHen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	 	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public class ExampleClass : MonoBehaviour {
		void Awake() {
			DontDestroyOnLoad(transform.gameObject);
		}
	}
}
