using UnityEngine;

public class Litter : DynamicBhv {
//	[SerializeField] private int coinValue = 3;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(GlobalVars.TAG_PLAYER)) {
			Instantiate(prefab, transform.position, Quaternion.identity, null);
			Destroy (gameObject);
		}
	}

}
