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
	public Canvas playerInterface;

	public Text levelText;
	public Text timeText;
	public Text foodCountText;

	public int numberOfChickensKilled; //kanske ska vara private sen

	//public Canvas quickMenu;

	//public GameObject menu;

	private int currentLevel = 0;

	private int foodCount = 0;



	private int gameTime = 0;
	private int gameStartTime = 0;


	// Use this for initialization
	void Start () {
		startMenu = startMenu.GetComponent<Canvas> ();
		failMenu = failMenu.GetComponent<Canvas> ();
		successMenu = successMenu.GetComponent<Canvas> ();
		playerInterface = playerInterface.GetComponent<Canvas> ();

		levelText = levelText.GetComponent<Text> ();
		timeText= timeText.GetComponent<Text> ();
		foodCountText = foodCountText.GetComponent<Text> ();



		startMenu.enabled = false;
		failMenu.enabled = false;
		successMenu.enabled = false;
		playerInterface.enabled = false;

		gameStartTime = Mathf.RoundToInt (Time.time);

		//quickMenu = quickMenu.GetComponent<Canvas> ();
	}

	// Update is called once per frame
	void Update () {
		if (gameWon()) {
			levelIsCompleted ();
		}

		//Cheets
		if (Input.GetKeyUp (KeyCode.Q)) {
			hideAllPopups ();
			startMenu.enabled = true;
		} else if (Input.GetKeyUp (KeyCode.W)) {
			hideAllPopups ();
			levelIsCompleted ();
		}
		else if (Input.GetKeyUp (KeyCode.E)) {
			hideAllPopups ();
			levelHasFailed ();
		}	
		else if (Input.GetKeyUp (KeyCode.R)) {
			hideAllPopups ();
			showPlayerInterface ();
		}	

		gameTime = Mathf.RoundToInt(Time.time - gameStartTime);


		levelText.text = "Level: " + currentLevel.ToString ();
		timeText.text = "Time: " + gameTime.ToString ();
		foodCountText.text = "Food: " + foodCount.ToString ();
	}

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

	}

	bool gameWon()
	{
		GameObject[] chickens = GameObject.FindGameObjectsWithTag ("chicken");
		if (chickens.Length > 0) {
			return false;
		} else {
			return true;
		}
	}

	//void initGame(){
	//	SceneManager.LoadScene (1);
	//

	public void startNextLevel(){
		numberOfChickensKilled = 0;
		currentLevel = currentLevel + 1;

		SceneManager.LoadScene (currentLevel);

		Debug.Log("Loading" + currentLevel);
		hideAllPopups ();	

		showPlayerInterface ();
	}

	public void restartLevel(){
		numberOfChickensKilled = 0;
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

	public void showStartMenu(){
		startMenu.enabled = true;
	}

	public void showPlayerInterface(){
		playerInterface.enabled = true;
	}

	public void hidePlayerInterface(){
		playerInterface.enabled = false;
	}


	public void ExitGame(){
		Application.Quit ();
	}



	//Get number of chickens in a level
	public int getChickenCount(int level){
		return level;
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

	public void increaseChickenKilledCount()
	{
		numberOfChickensKilled++;
	}


}
