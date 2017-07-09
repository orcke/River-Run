using UnityEngine;

public class TextReady : MonoBehaviour {
	
	void Update () {
		if (GameManager.instant.isPlayerActive) {
			Destroy (gameObject);
		} else {
			if (Input.GetMouseButtonDown (0)) {
				GameManager.instant.isPlayerActive = true;
				Destroy (gameObject);
			}
		}
	}
}
