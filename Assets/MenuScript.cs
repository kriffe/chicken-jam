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
		SceneManager.LoadScene (1);

	}

	public void ExitGame(){
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
