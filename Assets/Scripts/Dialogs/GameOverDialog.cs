using UnityEngine;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour {

	[SerializeField] Text tongDiem;

	public void buttonRePlay() {
		GameManager.instant.reset ();

		int currentLife = GameManager.instant.player.life;
		if (currentLife <= 0) {
			GameManager.instant.player.life = 3;
			GameManager.instant.player.score = 0;
		}
		GameManager.instant.loadScene(GlobalVars.GAME_TYPE);
	}

	void Start() {
		int score = GameManager.instant.player.score;
		string _tongDiem = "Tổng điểm: ";
		if (GameManager.instant.player.checkHighScore ()) {
			_tongDiem = "Chúc mừng em đạt điểm cao nhất: ";
		}

		tongDiem.text = _tongDiem + score.ToString ()
			+ " \n Em đã thu được " + (score / 3).ToString ("0")
			+ " rác! \n Hãy chơi lại để tái chế được nhiều rác trên sông hơn nữa nhé!";
	}
}
