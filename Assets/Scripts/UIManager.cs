using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField] private GameObject dialogPause;
	[SerializeField] private GameObject heart;
	private GameObject buttonPause;
	private GameObject lifeUIParent;

	void Awake(){
		buttonPause = transform.Find (GlobalVars.BUTTON_PAUSE).gameObject;
		lifeUIParent = transform.Find (GlobalVars.LIFE_NUMBER).gameObject;
	}

	void Update() {
		buttonPause.SetActive (GameManager.instant.isPlayerActive);
	}

	public void ChangeLifeNumberUI () {
//		Transform _transform = lifeUIParent.transform;
//		foreach (Transform child in _transform) {
//			GameObject.Destroy(child.gameObject);
//		}
//		for(int i = 0; i< GameManager.instant.player.life; i++)
//			Instantiate (heart, _transform.position, Quaternion.identity, _transform);
		LifeNumber lifeSct = lifeUIParent.GetComponent<LifeNumber>();
		lifeSct.ChangeLifeNumberUI ();
	}

	public void enableButtonPause(){
		buttonPause.SetActive (true);
	}

	public void showDialogPause() {
		GameManager.instant.isPlayerActive = false;
		if (dialogPause != null) {
			Instantiate (dialogPause, Vector3.zero, Quaternion.identity, transform);
		}
	}
}
