using UnityEngine;
using UnityEngine.UI;

public class UIGameRecycle : MonoBehaviour {
	[SerializeField] private Image imgContent;
	[SerializeField] private Image imgUI;

	[SerializeField] private Sprite[] spriteList;

	void Awake() {
		int index = Random.Range (0, spriteList.Length);

		if (index == 0) {
			GameManager.instant.player.life++;
		}

		imgUI.sprite = spriteList [index];
		imgContent.sprite = spriteList [index];

		GameManager.instant.player.score += 9;

	}
}
