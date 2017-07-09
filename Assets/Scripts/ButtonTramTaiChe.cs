using UnityEngine;

public class ButtonTramTaiChe : MonoBehaviour {

	public void TramTaiChe() {

		GameManager.instant.isPlayerActive = false;
		GameManager.instant.loadScene (GlobalVars.GAMERECYCLE);
	}
}
