using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impediment : DynamicBhv {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(GlobalVars.TAG_PLAYER)) {
			Instantiate(prefab, transform.position, Quaternion.identity, null);
			Camera cam = Camera.main;
			CameraShake camS = cam.GetComponent<CameraShake> ();
			camS.shake ();
			BoxCollider2D bx2D = GetComponent<BoxCollider2D> ();
			Physics2D.IgnoreCollision (bx2D, other);
		}
	}
}
