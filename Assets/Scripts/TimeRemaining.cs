using UnityEngine;
using UnityEngine.UI;

public class TimeRemaining : MonoBehaviour {
	private Text textDisplay;
	private float timeRemaining;

	void Start () {
		timeRemaining = GameManager.instant.timeRemainingLevel;
		textDisplay = GetComponent<Text> ();
	}

	void Update () {
		if (GameManager.instant.isPlayerActive) {
			timeRemaining -= Time.deltaTime;
			textDisplay.text = Mathf.Round(timeRemaining).ToString();
		}
	}
}
