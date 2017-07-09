using UnityEngine;

public class SelectPlayer : MonoBehaviour {
	[SerializeField] private GameObject tyArrow;
	[SerializeField] private GameObject suuArrow;

	void Awake() {
		suuArrow.SetActive (false);
	}


	public void selectBanTy(){
		GameManager.instant.suuPref.SetActive (false);
		GameManager.instant.tyPref.SetActive (true);
		suuArrow.SetActive (false);
		tyArrow.SetActive (true);
	}
	public void selectBanSuu(){
		GameManager.instant.suuPref.SetActive (true);
		GameManager.instant.tyPref.SetActive (false);
		suuArrow.SetActive (true);
		tyArrow.SetActive (false);
	}
}
