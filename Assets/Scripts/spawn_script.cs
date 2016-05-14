using UnityEngine;
using System.Collections;

public class spawn_script : MonoBehaviour {
    public GameObject chickenPrefab;

    private int numberOfChickens = 5;
    // Use this for initialization
    void Start () {
        for(int i = 0; i < numberOfChickens; i++)
        {
            GameObject chicken = (GameObject)Instantiate(chickenPrefab, new Vector3(i*2 , 0, 0), Quaternion.identity);
            chicken.tag = "chicken";
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
