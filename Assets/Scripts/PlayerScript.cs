using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private bool isChickenGrabbed;
	private Rigidbody grabbedChicken;
	private int chickenFlickMultipier = 100;

	public GameObject foodPrefab; 
	private int nrOfFoodLeft = 10;

	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		
		HandleChickenFlick ();
		HandleFoodSpawn ();

	}
		
	private void HandleChickenFlick(){
		
		if (Input.GetButton("Fire1") && !isChickenGrabbed) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {

				if (hit.collider.tag == "chicken" && !isChickenGrabbed) {

					isChickenGrabbed = true;
					Debug.Log ("Chicken is grabbed");
					grabbedChicken = hit.collider.gameObject.GetComponent<Rigidbody> ();
				}
			}
		}

		if (isChickenGrabbed) {

			Debug.Log ("Release the chicken!");

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Vector3 dirVector;

			// FIX: add mask to raycast
			if (Physics.Raycast (ray, out hit, 100)) {

				if (hit.collider.tag == "ground") {

					dirVector = grabbedChicken.transform.position - hit.point;

					grabbedChicken.rotation = Quaternion.LookRotation (dirVector);

				} else {
					dirVector = new Vector3 (1, 0, 0);
				}
			} else {
				dirVector = new Vector3 (1, 0, 0);
			}

			if (Input.GetButtonUp ("Fire1")) {
				Debug.Log ("Release the chicken");
				isChickenGrabbed = false;
				grabbedChicken.AddForce ((chickenFlickMultipier * dirVector.magnitude) * grabbedChicken.transform.forward);
				grabbedChicken.AddForce ((chickenFlickMultipier * dirVector.magnitude) * grabbedChicken.transform.up);
			}
		}
	}

	private void HandleFoodSpawn(){

		// Add food
		if (Input.GetButtonDown ("Fire2")) {

			Debug.Log ("Add food");

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {

				if (nrOfFoodLeft > 0) {

					Instantiate(foodPrefab, hit.point + new Vector3(0,1,0), Quaternion.identity);
					nrOfFoodLeft--;
				}

			}
		}
	}


	public int GetNrOfFood(){
		return nrOfFoodLeft;
	}
}
