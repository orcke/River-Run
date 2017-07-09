
using UnityEngine;

public class Game_Controller : MonoBehaviour {
	[SerializeField] private GameObject river;
	[SerializeField] private GameObject playerPrefabs;
	
	[SerializeField] Transform[] spawns;
	[SerializeField] GameObject[] litters;
	[SerializeField] GameObject[] barriers;
	private float timeRemaining = 0;

	void Awake() {
		Instantiate (playerPrefabs, playerPrefabs.transform.position, Quaternion.identity, null);
		Instantiate (river, river.transform.position, Quaternion.identity, null);
	}

	void Start() {
		InvokeRepeating ("initLitter", 1f, 0.85f);
	}

	private void initLitter(){
		if (GameManager.instant.isPlayerActive) {
			int randPos = Random.Range (0, spawns.Length);
			Vector3 initPos = spawns [randPos].position;
			int randLitter = Random.Range (0, litters.Length-1);
			int _timeRemain = Mathf.RoundToInt (timeRemaining) % 4;

			if (_timeRemain == 0 && timeRemaining > 8.0F) {
				randLitter = Random.Range (0, barriers.Length);
				Instantiate (barriers [randLitter], initPos, Quaternion.identity, null);
			} else 
				Instantiate (litters [randLitter], initPos, Quaternion.identity, null);
			
			if (timeRemaining >= GameManager.instant.timeRemainingLevel) {
				Instantiate (litters [litters.Length - 1], spawns [2].position, Quaternion.identity, null);
				timeRemaining = 0;
			}
		}
	}

	void Update () {
		if (GameManager.instant.isPlayerActive) {
			if (GameManager.instant.player.life <= 0) {
				GameManager.instant.isPlayerActive = false;
				GameManager.instant.loadScene (GlobalVars.GAMEOVER);
			}

			timeRemaining += Time.deltaTime;

		}

	}

}
