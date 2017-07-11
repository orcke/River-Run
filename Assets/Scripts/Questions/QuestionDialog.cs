using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDialog : MonoBehaviour {
	[SerializeField] private Text textQuestion;
	[SerializeField] private Text textTitle;
	[SerializeField] private Transform answerParent;
	[SerializeField] private GameObject answerButton;
	[SerializeField] private GameObject buttonTramTaiChe;

	private QuestionData questionData;
	private int questionIndex = -1;

	void Start() {
		string title = textTitle.text + " " + GameManager.instant.level;
		textTitle.text = title;
	}

	public int getQuestion() {
		List<QuestionData> listData = GameManager.instant.questionList;

		if (listData != null && listData.Count > 0) {
			questionIndex = Random.Range (0, listData.Count);
			questionData = listData [questionIndex];
			textQuestion.text = questionData.questionText;
//			Debug.Log ("Cau hoi Tram dung: " + questionData.questionText);
			AnswerData[] answerList = questionData.answers;
			for (int i = 0; i < answerList.Length; i++) {
				GameObject answerGO = Instantiate (answerButton, Vector3.zero, Quaternion.identity, answerParent);
				AnswerButton answerBtn = answerGO.GetComponent<AnswerButton> ();
				answerBtn.SetUp (answerList[i]);
			}
		} else
			questionIndex = -1;
		return questionIndex;
	}

	public void AnswerButtonClicked(bool isCorrect) {
		if (isCorrect) {
			GameManager.instant.questionList.Remove(questionData);
			Debug.Log ("questionList udpate: " + GameManager.instant.questionList.Count);

			setResultContent ("Chính xác!", null);

		} else {
			GameManager.instant.player.life--;
			GameObject _ui = GameObject.FindGameObjectWithTag (GlobalVars.TAG_UI);
			UIManager _uiManager = _ui.GetComponent<UIManager> ();
			_uiManager.ChangeLifeNumberUI ();

			setResultContent ("Ồ, em sai mất rồi \n Mình tiếp tục trò chơi nhé!", "Chơi tiếp");

//			Debug.Log ("tra loi sai" + GameManager.instant.questionList.Count);
		}
	}

	private void setResultContent(string title, string strButton) {
		foreach (Transform child in answerParent) {
			GameObject.Destroy(child.gameObject);
		}

		if (strButton != null) {
			textQuestion.text = title;
			StartCoroutine ("continueGame");
		} else {
			Instantiate (buttonTramTaiChe, Vector3.zero, Quaternion.identity, answerParent);
			textQuestion.text = title + " \n " + questionData.noteText;
		}
	}

	private IEnumerator continueGame() {
		// Do nothing
		yield return new WaitForSeconds (1.5F);
		Destroy (gameObject);
		GameManager.instant.isPlayerActive = true;
	}

}
