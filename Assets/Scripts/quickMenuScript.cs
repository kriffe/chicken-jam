using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class quickMenuScript : MonoBehaviour {

	public Canvas quickMenu;
	public Button startText;

	// Use this for initialization
	void Start () {
		quickMenu = quickMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
	}


	void StartApp(){
		GameManager.instance.startNextLevel ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
