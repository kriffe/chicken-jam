using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {


	private int foodCount = 10;
	private int currentLevel = 0;

	private int spawnTime = 0;

	private GameManager manager;


	public Text foodText;
	public Text levelText;
	public Text levelTimerText;

	// Use this for initialization
	void Start () {
		
		foodText.text = "Food: " + foodCount;

		spawnTime = Mathf.RoundToInt (Time.time);

	}
	
	// Update is called once per frame
	void Update () {
		foodText.text = "Food: " + currentLevel;
		levelTimerText.text = (Mathf.RoundToInt(Time.time)-spawnTime).ToString () + " s";
		levelText.text = currentLevel.ToString();
	}

	public void setLevel(int level){
		currentLevel = level;
	}
}
