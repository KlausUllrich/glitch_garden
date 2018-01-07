using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {


	void Start () {
	
		// Master Volume
		Debug.Log ("initial Volume: " + PlayerPrefsManager.GetMasterVolume());
		PlayerPrefsManager.SetMasterVolume (0.75f);
		Debug.Log ("set Volume (0.75): " + PlayerPrefsManager.GetMasterVolume());


		// Unlock level
		Debug.Log("initial Level 03 unlocked? " + PlayerPrefsManager.IsLevelUnlocked(3));
		PlayerPrefsManager.UnlockLevel (3);
		Debug.Log("Level 03 now unlocked? " + PlayerPrefsManager.IsLevelUnlocked(3));


		// Set Difficulty
		Debug.Log ("initial difficulty: " + PlayerPrefsManager.GetDifficulty());
		PlayerPrefsManager.SetDifficulty (4);
		Debug.Log("set difficulty (0.4): " + PlayerPrefsManager.GetDifficulty());
	}
	

	void Update () {
	
	}
}
