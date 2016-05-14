using UnityEngine;
using System.Collections;

public class food_script : MonoBehaviour {
    private int numberOfChickensInside = 0;
    public float timer;
	// Use this for initialization
	void Start () {
        Debug.Log("food script started");
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "chicken")
        {
            numberOfChickensInside = numberOfChickensInside + 1;
            Debug.Log("number of chickens are now: " + numberOfChickensInside);
        }
        else
        {
            Debug.Log(other.tag + " entered food");
        }
    }

    void OnTriggerExit(Collider other)
    {
        numberOfChickensInside = numberOfChickensInside - 1;
        print("number of chickens are now: " +  numberOfChickensInside);
    }

    // Update is called once per frame
    void Update () {
        if(timer > 0)
        {
            updateTimer(numberOfChickensInside);
        }
        else
        {
            numberOfChickensInside = 0;
            Destroy(gameObject);
            Debug.Log("Out of Time");
        }
	}

    void updateTimer(int numberOfChickens)
    {
        timer = timer - numberOfChickensInside * Time.deltaTime;
    }
}
