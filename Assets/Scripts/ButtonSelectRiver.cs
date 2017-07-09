using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectRiver : MonoBehaviour {

	void Start() {
		GameManager.instant.RiverSelected (0);
	}

	public void selectSongHong() {
		GameManager.instant.RiverSelected (0);
//		Debug.Log ("Nguoi choi chon Song Hong");
	}
	public void selectSongNhue() {
		GameManager.instant.RiverSelected (1);
//		Debug.Log ("Nguoi choi chon Song Nhue");
	}
	public void selectSongTolich() {
		GameManager.instant.RiverSelected (2);
//		Debug.Log ("Nguoi choi chon To Lich");
	}
}
