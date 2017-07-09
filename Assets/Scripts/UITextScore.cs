
using UnityEngine;
using UnityEngine.UI;

public class UITextScore : MonoBehaviour {
	private Text textDisplay;
	
	void Start () {
		textDisplay = GetComponent<Text> ();
	}

	void LateUpdate () {
		textDisplay.text = GameManager.instant.getCurrentScore ().ToString();
	}
}
