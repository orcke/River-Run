using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour {
	private float leftSide = -3.0F;
	private float rightSide = 3.0F;
	private Vector2 velocity;
	private bool isRight;
	private Rigidbody2D rgb2D;

	public float speed = 4.00f;

	void Start () {
		rgb2D = GetComponent<Rigidbody2D> ();
		var cachePos = transform.position;
		if (cachePos.x < 0) {
			isRight = false;
		} else {
			isRight = true;
		}
		velocity = new Vector2 (speed, 0);
	}

	void Update () {
		if (GameManager.instant.isPlayerActive) {
			if (Input.GetMouseButtonDown (0))
				isRight = !isRight;

			if (isRight) {
				rgb2D.velocity = velocity;
			} else {
				rgb2D.velocity = -velocity;
			}
		} else {
			rgb2D.velocity = Vector2.zero;
		}

		Vector3 _pos = transform.position;
		_pos.x = Mathf.Clamp (_pos.x, leftSide, rightSide);
		transform.position = _pos;
	}

}
