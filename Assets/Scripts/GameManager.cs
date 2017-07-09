using System.IO;           			// The System.IO namespace contains functions related to loading and saving files
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {
	public static GameManager instant;
	[SerializeField] private RoundData[] allRoundData;
	[HideInInspector] public List<QuestionData> questionList = new List<QuestionData>();

	[SerializeField] private Sprite[] riverSprite;
	[SerializeField] private SpriteRenderer riverPrefab;
	public GameObject tyPref;
	public GameObject suuPref;
	private float velocityLevel = 0.015F;

	public bool isPlayerActive = false;
	public PlayerObj player;
	public float timeRemainingLevel = 90; // seconds
	public int level = 1;

	private string gameDataFileName = "data.json";

	public void reset() {
		player = new PlayerObj ();
		GameInfo info = new GameInfo ();
		velocityLevel = info.velocityLevel;
		level = info.level;
		timeRemainingLevel = info.timeRemainingLevel;
	}

	public float getVelocity() {
		return velocityLevel;
	}

	public void setVelocity(){
		velocityLevel *= 1.1486F;
	}

	public int getCurrentScore() {
		return player.score;
	}

	public void PlushScore() {
		player.score += 3;
	}

	public void RiverSelected(int index) {
		if (index >= 0 && index < riverSprite.Length) {
			riverPrefab.sprite = riverSprite [index];
			setUpQuestionData (index);
		}
	}

	private void setUpQuestionData(int index) {
		if (allRoundData != null) {
			var currentRoundData = allRoundData [index];
			var question1 = currentRoundData.questions;
			var generalRoundData = allRoundData [allRoundData.Length - 1];
			var question2 = generalRoundData.questions;
			questionList = question1.Concat (question2).ToArray().ToList();
			//				Debug.Log("all Round Data " + allRoundData.Length);
//			Debug.Log("current Questions " + questionList.Count);
		}
	}

	private void LoadQuestionData() {
		// Path.Combine combines strings into a file path Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

		if(File.Exists(filePath)) {
			// Read the json from the file into a string
			string dataAsJson = File.ReadAllText(filePath); 
			// Pass the json to JsonUtility, and tell it to create a GameData object from it
			GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

			// Retrieve the allRoundData property of loadedData
			allRoundData = loadedData.allRoundData;
		} else {
//			Debug.LogError("Cannot load game data!");
		}
	}

	void Awake () {
		if(!instant) {
			instant = this;
			DontDestroyOnLoad(this);
		} else 
			Destroy(gameObject);
	}
	void Start  () {
		reset ();
		if(allRoundData.Length <= 0) LoadQuestionData ();
	}

	public void loadScene(string name) {
		SceneManager.LoadScene (name);
	}

}
