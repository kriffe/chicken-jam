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
		//initGame ();
		Debug.Log("Loading" + currentLevel);

	}

	public void restartLevel(){
		currentLevel = currentLevel + 1;

		SceneManager.LoadScene (currentLevel);
		//initGame ();
		Debug.Log("Loading" + currentLevel);

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
		successMenu.enabled = true;

		//quickMenu = quickMenu.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			Debug.Log ("Esc");
		
		}	
	}


	public void increaseFoodCount(){
		foodCount = foodCount + 1;
	}

	public void decreaseFoodCount(){
		foodCount = foodCount - 1;
	}

	public int getFoodCount(){
		return foodCount;
	}


}
