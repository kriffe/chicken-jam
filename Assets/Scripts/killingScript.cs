﻿using UnityEngine;
using System.Collections;

public class killingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        Debug.Log("killingScript started");
	}
    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "chicken")
        {
            
			var chickenScript = other.gameObject.GetComponent<chicken_script> ();

			chickenScript.Kill ();
			//Destroy(other.gameObject);



            Debug.Log("chicken killed");

			if (this.tag != "Finish") {
				GameManager.instance.increaseChickenKilledCount();
			}
		
        }



    }
    // Update is called once per frame
    void Update () {
	
	}
}
