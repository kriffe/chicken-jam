using UnityEngine;
using System.Collections;

public class food_script : MonoBehaviour {
    public int numberOfChickensInside = 0;
    public float timer;
    public int radius;
	// Use this for initialization
	void Start () {
        Debug.Log("food script started");

		//GameManager.instance.getChickenCount()
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "chicken")
        {
            numberOfChickensInside = numberOfChickensInside + 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        numberOfChickensInside = numberOfChickensInside - 1;
    }

    // Update is called once per frame
    void Update () {
        if(timer > 0)
        {
            updateTimer(numberOfChickensInside);
        }
        else
        {

            increaseNrOfFoods();
            GameManager.instance.increaseFoodCount();
            Debug.Log("Out of Time");
            Destroy(gameObject);
        }
	}

    void updateTimer(int numberOfChickens)
    {
        timer = timer - numberOfChickensInside * Time.deltaTime;
    }

    void increaseNrOfFoods()
    {

        PlayerScript playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerScript.increaseNrOfFood();
    }
}
