using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushEffect : MonoBehaviour {
	private GameObject target;
	private float t;
	
	void Start () {
		t = 0;
		target = GameObject.FindGameObjectWithTag (GlobalVars.TAG_END);
	}

	void Update () {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag (GlobalVars.TAG_END);
			return;
		}
		t += Time.deltaTime * 0.1F;
		transform.position = Vector3.Lerp(transform.position, target.transform.position, t);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(GlobalVars.TAG_END)) {
			GameManager.instant.PlushScore ();
			Destroy (gameObject);
		}
	}
}
