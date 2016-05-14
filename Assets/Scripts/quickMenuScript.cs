using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class quickMenuScript : MonoBehaviour {

	//public Canvas quickMenu;
	//public Button startText;

	// Use this for initialization
	void Start () {
	//	quickMenu = quickMenu.GetComponent<Canvas> ();
	//	startText = startText.GetComponent<Button> ();
	}


	public void startNextLevel(){
		GameManager.instance.startNextLevel ();
	}


	//public void hideQuickMenu(){
	//	quickMenu.enabled = false;
	//}

	//public void showQuickMenu(){
	//	quickMenu.enabled = true;
	//}

	// Update is called once per frame
	void Update () {
	
	}
}
