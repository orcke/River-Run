using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBhv : MonoBehaviour {
	private Rigidbody2D rgb2D;
	protected Vector2 velocityDir = new Vector2 (0, -0.05F);
	[SerializeField] protected GameObject prefab;
	private Vector3 cachePos = Vector3.zero;

	virtual protected void Start() {
		cachePos = transform.position;
		rgb2D = GetComponent<Rigidbody2D> ();
		velocityDir = new Vector2 (0, -GameManager.instant.getVelocity());
	}

	virtual protected void FixedUpdate() {
		if (GameManager.instant.isPlayerActive) {
			rgb2D.velocity += velocityDir;
		}
	}

	virtual protected void LateUpdate () {
		if (GameManager.instant.isPlayerActive) {
			cachePos = transform.position;
			cachePos.z = 5.00F * cachePos.y + 723.00F;
			var cacheX = cachePos.x;
			if (cacheX < 0)
				cachePos.x = 0.14419F * cachePos.y - 1.96327F;
			else if (cacheX > 0)
				cachePos.x = -0.14419F * cachePos.y + 1.96327F;
		}
		transform.position = cachePos;
		float scale = -0.0849F * cachePos.y + 0.4623F;
		Vector3 vScale = new Vector3 (scale, scale, 1);
		transform.localScale = vScale;
	}
}
