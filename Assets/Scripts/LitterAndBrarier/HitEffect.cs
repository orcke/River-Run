using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {
	private GameObject _ui;
	void Start () {
		GameManager.instant.isPlayerActive = false;
		_ui = GameObject.FindGameObjectWithTag (GlobalVars.TAG_UI);
		Destroy (gameObject, 0.35F);
	}
	void Update() {
		if(_ui == null)
			_ui = GameObject.FindGameObjectWithTag (GlobalVars.TAG_UI);
	}
	void OnDestroy(){
		GameManager.instant.player.life--;
		if (_ui != null) {
			UIManager _uiManager = _ui.GetComponent<UIManager> ();
			_uiManager.ChangeLifeNumberUI ();
		}
		GameManager.instant.isPlayerActive = true;
	}
}
