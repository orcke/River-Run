using UnityEngine;
using System.Collections;

public class buttonTieptuc : MonoBehaviour {

	public void tiepTuc(){
		int level = GameManager.instant.level;
		if (level >= 5) {
			
			GameManager.instant.loadScene (GlobalVars.GAMECOMPLETE);
		} else {
			float time = GameManager.instant.timeRemainingLevel;
			GameManager.instant.timeRemainingLevel -= time * 0.15F;
			GameManager.instant.setVelocity ();
			GameManager.instant.level = level + 1;
			GameManager.instant.isPlayerActive = true;
			GameManager.instant.loadScene (GlobalVars.GAME_PLAY);
		}
	}

}
