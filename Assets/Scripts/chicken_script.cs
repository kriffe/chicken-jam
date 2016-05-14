using UnityEngine;
using System.Collections;

public class chicken_script : MonoBehaviour {
    private GameObject[] foods;
    private GameObject closestFood;
    public int speed = 5    ;
	// Use this for initialization
	void Start () {

    }
    

    // Update is called once per frame
    void Update ()
    {
        foods = GameObject.FindGameObjectsWithTag("food");
        if(foods.Length> 0)
        {
            transform.rotation.Set(0, transform.rotation.y, 0, transform.rotation.w);
            closestFood = getClosestFoodSource(foods);
            moveChicken(closestFood, speed);
        }
        else
        {
            //Debug.Log("no food left!");
        }

		//transform.rotation = Quaternion.FromToRotation (transform.rotation.eulerAngles, new Vector3 (0, transform.rotation.y, 0));

    }

    float getDistance(GameObject food)
    {
        Vector3 foodPos = food.transform.position;
        Vector3 chickenPos = this.transform.position;
        float distance = Vector3.Distance(chickenPos, foodPos);
        return distance;
    }

    Vector3 getDirection(GameObject food)
    {
        return food.transform.position - this.transform.position;
    }

    public void moveChicken(GameObject food, int speed)
    {
        rotateChickenToFoodSource(food);
        //måste anpassas efter radius på spherecollider på food
        if(getDistance(food) > 2)
        {
            //matens x och z-komponent och hönans y-komponent
            Vector3 foodGroundPosition = new Vector3(food.transform.position.x, this.transform.position.y, food.transform.position.z);
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, foodGroundPosition, step);
        }
        //this.transform.position = Vector3.Lerp(this.transform.position, foodGroundPosition, speed * Time.deltaTime);
        
    }

    private void rotateChickenToFoodSource(GameObject food)
    {
        
        this.transform.LookAt(food.transform.position);
    }

    //här ska det implementeras nåt som kollar vilken i listan som har kortast absolutbelopp från kyckling till food
    GameObject getClosestFoodSource(GameObject[] foods)
    {
        
        GameObject closestFood = foods[0];
        float lastDistance = -1; //-1 för att den är oanvänd
        foreach (GameObject food in foods)
        {
            float tempDistance = getDistance(food);
            
            if(tempDistance < lastDistance || lastDistance == -1)
            {
                closestFood = food;
                lastDistance = tempDistance;
            }
        }
        return closestFood;
    }
}

