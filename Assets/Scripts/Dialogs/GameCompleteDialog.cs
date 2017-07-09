
using UnityEngine;
using UnityEngine.UI;

public class GameCompleteDialog : MonoBehaviour {

	[SerializeField] Text tongDiem;
	
	public void buttonContinue() {
		
		GameManager.instant.reset ();
		GameManager.instant.loadScene(GlobalVars.GAME_MENU);
	}
	
	public void buttonRePlay() {
		
		GameManager.instant.reset ();
		GameManager.instant.loadScene(GlobalVars.GAME_TYPE);
	}

	void Start() {
		int score = GameManager.instant.player.score;
		tongDiem.text = "Chúc mừng em đạt được " + score.ToString () + " điểm!";
	}
}
