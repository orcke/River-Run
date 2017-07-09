using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
//	[SerializeField] private Text textCount;
	[SerializeField] private int timeToCount = 2;

	void Start () {
		StartCoroutine ("Countdown", timeToCount);
	}

	private IEnumerator Countdown(int time){
		while(time > 0){
			time--;
//			if (textCount != null) textCount.text = time.ToString();
			yield return new WaitForSeconds(1);
		}
		Destroy (gameObject);
	}

	void OnDestroy() {
		GameManager.instant.loadScene(GlobalVars.GAME_MENU);
//		Debug.Log("Countdown Complete!");
	}
}
