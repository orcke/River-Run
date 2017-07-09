using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerButton : MonoBehaviour  {
	public Text answerText;

	private QuestionDialog questionDialog;
	private AnswerData answerData;

	public void SetUp(AnswerData data) {
		answerData = data;
		answerText.text = answerData.answerText;
		Transform parentTrans1 = transform.parent;
		Transform parentTrans2 = parentTrans1.parent;
		GameObject gameParent = parentTrans2.gameObject;
		questionDialog = gameParent.GetComponent<QuestionDialog> ();
	}

	public void HandleClick() {
		questionDialog.AnswerButtonClicked(answerData.isCorrect);
	}
}
