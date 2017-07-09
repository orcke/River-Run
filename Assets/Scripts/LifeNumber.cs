using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeNumber : MonoBehaviour {
	[SerializeField] private GameObject hearth;

	void Start () {
		ChangeLifeNumberUI ();
	}

	public void ChangeLifeNumberUI () {
		
		foreach (Transform child in transform) {
			if(child != null) GameObject.Destroy(child.gameObject);
		}
		for(int i = 0; i< GameManager.instant.player.life; i++)
			Instantiate (hearth, hearth.transform.position, Quaternion.identity, transform);
	}
}
