
using UnityEngine;

public class Stopper : DynamicBhv {

	protected override void Start(){
		base.Start ();
		velocityDir *= 0.75F;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(GlobalVars.TAG_PLAYER)) {
			GameManager.instant.isPlayerActive = false;
			BoxCollider2D bx2D = GetComponent<BoxCollider2D> ();
			Physics2D.IgnoreCollision (bx2D, other);
			DisplayQuestionsDialog ();
		}
	}
	private void DisplayQuestionsDialog() {
		GameObject _ui = GameObject.FindGameObjectWithTag (GlobalVars.TAG_UI);

		GameObject dialog = Instantiate (prefab, prefab.transform.position, Quaternion.identity, _ui.transform); // show dialog
		QuestionDialog question = dialog.GetComponent<QuestionDialog>();
		question.getQuestion ();

		Destroy (gameObject, 1.35F);
	}

}
