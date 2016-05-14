using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public LevelManager levelScript;

	public Player player;

	private int currentLevel = 1;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		levelScript = GetComponent<LevelManager>();

		player = GetComponent<Player> ();

		player.setLevel (5);

	}

	void initGame(){
		levelScript.SetupScene (1);
		player.setLevel (1);


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
