using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private bool isChickenGrabbed;
	private Rigidbody grabbedChicken;
	private int chickenFlickMultipier = 100;

	public GameObject foodPrefab; 
	private int nrOfFoodLeft = 10;

	private LineRenderer lineRenderer;
	private int lengthOfLineRenederer = 4;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetWidth (0.8f, 0.8f);
		lineRenderer.SetVertexCount (lengthOfLineRenederer);
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

			if (Physics.Raycast (ray, out hit, 1000)) {

				if (hit.collider.tag == "chicken" && !isChickenGrabbed) {

					isChickenGrabbed = true;
					Debug.Log ("Chicken is grabbed");
					grabbedChicken = hit.collider.gameObject.GetComponent<Rigidbody> ();
				}
			}
		}

		lineRenderer.SetPosition (0, new Vector3(0,100,0));
		lineRenderer.SetPosition (1, new Vector3(0,100,0));
		lineRenderer.SetPosition (2, new Vector3(0,100,0));
		lineRenderer.SetPosition (3, new Vector3(0,100,0));


		if (isChickenGrabbed) {

			Debug.Log ("Release the chicken!");

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Vector3 dirVector;

			// FIX: add mask to raycast
			if (Physics.Raycast (ray, out hit, 1000)) {

				if (hit.collider.tag == "ground") {

					dirVector = grabbedChicken.transform.position - hit.point;

					grabbedChicken.rotation = Quaternion.LookRotation (new Vector3(dirVector.x, 0, dirVector.z));



				} else {
					dirVector = new Vector3 (1, 0, 0);
				}
			} else {
				dirVector = new Vector3 (1, 0, 0);
			}


			float dirMagnitude = dirVector.magnitude;

			if (Input.GetButtonUp ("Fire1")) {
				Debug.Log ("Release the chicken");
				isChickenGrabbed = false;
				grabbedChicken.AddForce ((chickenFlickMultipier * dirMagnitude) * grabbedChicken.transform.forward);
				grabbedChicken.AddForce ((chickenFlickMultipier * dirMagnitude) * grabbedChicken.transform.up);
			}

			// draw lineRenderer
			Debug.Log(dirMagnitude);
			Color c1 = new Color (dirMagnitude / 10, 1-(dirMagnitude / 10),  - (dirMagnitude / 10) );
			lineRenderer.material = new Material (Shader.Find ("Particles/Additive"));
			lineRenderer.SetColors (c1, c1);

			lineRenderer.SetPosition (0, grabbedChicken.transform.position);
			lineRenderer.SetPosition (1, grabbedChicken.transform.position);
			lineRenderer.SetPosition (2, hit.point);
			lineRenderer.SetPosition (3, hit.point);


			//lineRenderer.SetColors(
		}
	}

	private void HandleFoodSpawn(){

		// Add food
		if (Input.GetButtonDown ("Fire2")) {

			Debug.Log ("Add food");

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1000)) {

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
