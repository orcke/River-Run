using UnityEngine;

public class PlayerObj {
	private string key = "highscore";
	private string keyLife = "life";
	private string keyScore = "score";

	private int mLife = 3;
	private int mScore = 0;
	private int mLevel = 1;

//	public int life {
//		get { 
//			if (PlayerPrefs.HasKey (keyLife)) {
//				int life_ = PlayerPrefs.GetInt (keyLife);
//				return life_;
//			} else {
//				return mLife;
//			}
//		}
//		set { mLife = value; }
//	}
	public int life {
		get { return getLife(); }
		set { 
			mLife = value; 
			PlayerPrefs.SetInt (keyLife, mLife);
		}
	}

//	public int score {
//		get { 
//			if (PlayerPrefs.HasKey (keyScore)) {
//				int score_ = PlayerPrefs.GetInt (keyScore);
//				return score_;
//			} else {
//				return mScore;
//			}
//		}
//
//		set { mScore = value; }
//	}
	public int score {
		get { return getScore(); }
		set { 
			mScore = value; 
			PlayerPrefs.SetInt (keyScore, mScore);
		}
	}

	public int level {
		get { return mLevel; }
		set { mLevel = value; }
	}
	private int getScore() {
		if (PlayerPrefs.HasKey (keyScore)) {
			int score_ = PlayerPrefs.GetInt (keyScore);
			return score_;
		} else {
			PlayerPrefs.SetInt (keyScore, mScore);
			return mScore;
		}
	}
	private int getLife() {
		if (PlayerPrefs.HasKey (keyLife)) {
			int life_ = PlayerPrefs.GetInt (keyLife);
			return life_;
		} else {
			PlayerPrefs.SetInt (keyLife, mLife);
			return mLife;
		}
	}

	public bool checkHighScore() {
		if(PlayerPrefs.HasKey(key)) {
			int highScore = PlayerPrefs.GetInt (key);
			return isHighScore (highScore);
		} else {
			int highScore = 0;
			PlayerPrefs.SetInt (key, highScore);
			return isHighScore (highScore);
		}
	}
	private bool isHighScore(int highScore) {
		if (highScore < mScore) {
			PlayerPrefs.SetInt (key, mScore);
			return true;
		} else
			return false;
	}
}
