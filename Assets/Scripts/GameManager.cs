using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public Canvas quickMenu;



	//public GameObject menu;

	private int currentLevel = 0;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);


	}

	void initGame(){
		SceneManager.LoadScene (1);
	}

	public void startNextLevel(){
		currentLevel = currentLevel + 1;

		SceneManager.LoadScene (currentLevel);
		//initGame ();
		Debug.Log("Loading" + currentLevel);
	

	}

	public void hideQuickMenu(){
		quickMenu.enabled = false;
	}

	public void showQuickMenu(){
		quickMenu.enabled = true;
	}


	public void ExitGame(){
		Application.Quit ();
	}



	//Get number of chickens in a level
	public int getChickenCount(int level){
		return level;
	}
		

	// Use this for initialization
	void Start () {
		quickMenu = quickMenu.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Listen after Esc
		if (Input.GetKey(KeyCode.Escape))
		{
			Debug.Log ("Esc");
			showQuickMenu ();
		}
		
	}
}
