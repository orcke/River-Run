using UnityEngine;
using UnityEngine.UI;

public class ButtonDialogPause : MonoBehaviour {
	[SerializeField] Text tongDiem;

	public void buttonContinue() {
		GameObject UI = transform.parent.gameObject;
		UIManager uiManager = UI.GetComponent<UIManager> ();
		uiManager.enableButtonPause ();
		GameManager.instant.isPlayerActive = true;
		Destroy (gameObject);
	}

	public void buttonRePlay() {
		GameManager.instant.reset ();
		GameManager.instant.isPlayerActive = false;

		GameManager.instant.loadScene(GlobalVars.GAME_MENU);
	}

	void LateUpdate() {
		tongDiem.text = "Em đang có " + GameManager.instant.player.score.ToString() + " đồng tiền vàng!";
	}
}
