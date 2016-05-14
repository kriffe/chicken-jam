using UnityEngine;
using System.Collections;

public class spawnChickens : MonoBehaviour {


	public GameObject chicken;

	private Vector3 position;

	// Use this for initialization
	void Start () {


		position = this.transform.position;

		//Instantiate(chicken,position, new Quaternion());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
