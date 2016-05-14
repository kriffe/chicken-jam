using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Button startText;
	public Button exitText;




	// Use this for initialization
	void Start () {
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}

	 
	public void StartLevel(){
		startText.enabled = false;
		GameManager.instance.startNextLevel ();
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void hide(){
		
		exitText.enabled = false;
	}

	public void show(){
		startText.enabled = true;
		exitText.enabled = true;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
