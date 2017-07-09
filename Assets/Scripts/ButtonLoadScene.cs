using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoadScene : MonoBehaviour {

	public void loadGameMenuScene() {
		GameManager.instant.loadScene (GlobalVars.GAME_MENU);
	}
	public void loadGamePlayScene() {
		GameManager.instant.loadScene (GlobalVars.GAME_PLAY);
	}
	public void loadGameTypeScene() {
		
		GameManager.instant.loadScene (GlobalVars.GAME_TYPE);
	}

}
