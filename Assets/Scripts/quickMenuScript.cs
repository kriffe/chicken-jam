using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class quickMenuScript : MonoBehaviour {

	public Canvas quickMenu;
	private bool quickMenuVisible = true;

	public bool firstLevel;

	//public Button startText;

	// Use this for initialization
	void Start () {
		if (firstLevel) {
			
		}
	//	quickMenu = quickMenu.GetComponent<Canvas> ();
	//	startText = startText.GetComponent<Button> ();
	}



	public void startNextLevel(){
		GameManager.instance.startNextLevel ();
	}

	public void ExitGame(){
		Application.Quit ();
	}



	public void hideQuickMenu(){
		quickMenu.enabled = false;
	}

	public void showQuickMenu(){
		quickMenu.enabled = true;
	}

	public void debugFunction1(){
		Debug.Log ("Debug!");
		//GameManager.instance.levelIsCom
	}

	// Update is called once per frame
	void Update () {
		quickMenu = quickMenu.GetComponent<Canvas> ();
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			Debug.Log ("Esc");
			if (quickMenuVisible){
				hideQuickMenu();
			}
			else{
				showQuickMenu();
			}
		}	
	}
}
