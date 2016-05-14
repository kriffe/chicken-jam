using UnityEngine;
using System.Collections;

public class spawn_script : MonoBehaviour {
    public GameObject chickenPrefab;
    public GameObject foodPrefab;
    // Use this for initialization
    void Start () {
        GameObject food = (GameObject)Instantiate(foodPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject chicken = (GameObject)Instantiate(chickenPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
