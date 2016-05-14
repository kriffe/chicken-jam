using UnityEngine;
using System.Collections;

public class DemoCube : MonoBehaviour {

	Vector3 diff = new Vector3(0,0,0);
	Vector3 target = new Vector3(0,0,0);
	Vector3 nextPos = new Vector3(0,0,0);

	Vector3 startPos = new Vector3(0,0,0);
	float dist = 10;
	float speed = 1;
	float dT = 0;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		dT = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		dT = Time.time - dT;

		target = startPos + new Vector3 (dist*Mathf.Sin (Time.time/1000), dist*Mathf.Sin(Time.time/1000), 0);

		nextPos = target;
		Debug.Log (nextPos);
		this.transform.position = nextPos;

	}
}
