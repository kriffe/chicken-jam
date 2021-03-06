﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private bool isChickenGrabbed;
	private Rigidbody grabbedChicken;
	private int chickenFlickMultipier = 100;

	public GameObject foodPrefab;

	public int foodStartCount = 3;
	public int chickenWinNumber = 3;
	private int nrOfFoodLeft;

	public string levelMessage;

	public LayerMask chickenLayerMask;
	public LayerMask groundLayerMask;

	private LineRenderer lineRenderer;
	private int lengthOfLineRenederer = 4;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetWidth (3f, 3f);
		lineRenderer.SetVertexCount (lengthOfLineRenederer);

		nrOfFoodLeft = foodStartCount;
		GameManager.instance.setFoodCount (nrOfFoodLeft);
		GameManager.instance.setChickenWonNumber (chickenWinNumber);
		GameManager.instance.setMessage (levelMessage);
	}

	// Update is called once per frame
	void Update () {
		
		HandleChickenFlick ();
		HandleFoodSpawn ();
		GameManager.instance.setFoodCount (nrOfFoodLeft);
	}
		
	private void HandleChickenFlick(){
		
		if (Input.GetButton("Fire1") && !isChickenGrabbed) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1000, chickenLayerMask)) {

				if (hit.collider.tag == "chicken" && !isChickenGrabbed) {

					isChickenGrabbed = true;
					Debug.Log ("Chicken is grabbed");
					var chickenScript = hit.collider.gameObject.GetComponent<chicken_script> ();

					chickenScript.setIsGrabbed (true);

					grabbedChicken = hit.collider.gameObject.GetComponent<Rigidbody> ();
				}
			}
		}

		lineRenderer.SetPosition (0, new Vector3(0,100,0));
		lineRenderer.SetPosition (1, new Vector3(0,100,0));
		lineRenderer.SetPosition (2, new Vector3(0,100,0));
		lineRenderer.SetPosition (3, new Vector3(0,100,0));


		if (isChickenGrabbed) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Vector3 dirVector;

			// FIX: add mask to raycast
			if (Physics.Raycast (ray, out hit, 1000, groundLayerMask) && hit.collider.tag == "ground") {
				
				dirVector = grabbedChicken.transform.position - hit.point;
				grabbedChicken.rotation = Quaternion.LookRotation (new Vector3(dirVector.x, 0, dirVector.z));

			} else {
				dirVector = new Vector3 (1, 0, 0); // I hope this does not happen
			}


			float dirMagnitude = dirVector.magnitude;

			if (Input.GetButtonUp ("Fire1")) {
				Debug.Log ("Release the chicken");

				var chickenScript = grabbedChicken.gameObject.GetComponent<chicken_script> ();
				chickenScript.setIsGrabbed (false);

				isChickenGrabbed = false;
				grabbedChicken.AddForce ((chickenFlickMultipier * dirMagnitude) * grabbedChicken.transform.forward);
				grabbedChicken.AddForce ((chickenFlickMultipier * dirMagnitude * 1.5f) * grabbedChicken.transform.up);
			}

			// draw lineRenderer
			Debug.Log(dirMagnitude);
			Color c1 = new Color (dirMagnitude / 10, 1-(dirMagnitude / 10),  - (dirMagnitude / 10) );
			lineRenderer.material = new Material (Shader.Find ("Particles/Additive"));
			lineRenderer.SetColors (c1, c1);

			lineRenderer.SetPosition (0, grabbedChicken.transform.position + new Vector3(0,1f,0));
			lineRenderer.SetPosition (1, grabbedChicken.transform.position+ new Vector3(0,1f,0));
			lineRenderer.SetPosition (2, hit.point+ new Vector3(0,1f,0));
			lineRenderer.SetPosition (3, hit.point+ new Vector3(0,1f,0));


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
                    GameManager.instance.decreaseFoodCount();
                }

			}
		}
	}


	public int GetNrOfFood(){
		return nrOfFoodLeft;
	}

    public void increaseNrOfFood()
    {
        nrOfFoodLeft++;
    }
}
