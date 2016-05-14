using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public Canvas startMenu;
	//public Canvas pauseMenu;
	public Canvas failMenu;
	public Canvas successMenu;

	//public Canvas quickMenu;

	//public GameObject menu;

	private int currentLevel = 0;

	private int foodCount = 0;

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

		Debug.Log("Loading" + currentLevel);
		hideAllPopups ();	

	}

	public void restartLevel(){
		SceneManager.LoadScene (currentLevel);
		hideAllPopups ();
	}

	public void debugFunc1(){
		Debug.Log ("Debug!");
	}


	public void levelIsCompleted(){
		successMenu.enabled = true;
		failMenu.enabled = false;
	}

	public void levelHasFailed(){
		failMenu.enabled = true;
		successMenu.enabled = false;
	}

	public void hideAllPopups(){
		successMenu.enabled = false;
		startMenu.enabled = false;
		failMenu.enabled = false;
		
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
		startMenu = startMenu.GetComponent<Canvas> ();
		failMenu = failMenu.GetComponent<Canvas> ();
		successMenu = successMenu.GetComponent<Canvas> ();

		startMenu.enabled = false;
		failMenu.enabled = false;
		successMenu.enabled = false;

		//quickMenu = quickMenu.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Cheets
		if (Input.GetKeyUp (KeyCode.Q)) {
			startMenu.enabled = true;
		} else if (Input.GetKeyUp (KeyCode.W)) {
			levelIsCompleted ();
		}
		else if (Input.GetKeyUp (KeyCode.E)) {
			levelHasFailed ();
		}
	}


	public void increaseFoodCount(){
		foodCount = foodCount + 1;
	}

	public void decreaseFoodCount(){
		foodCount = foodCount - 1;
	}

	public void setFoodCount(int value){
		foodCount = value;
	}

	public int getFoodCount(){
		return foodCount;
	}




}
