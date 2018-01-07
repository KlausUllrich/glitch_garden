using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	/// <summary>
	/// Sets the master volume. Needs to be between 0 and 1.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public static void SetMasterVolume (float volume){
		if (volume > 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume not between 0 and 1");
		}
	}

	/// <summary>
	/// Gets the master volume.
	/// </summary>
	/// <returns>The master volume.</returns>
	public static float GetMasterVolume (){
		float volume = PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
		if (volume > 0f && volume <= 1f) {
			return volume;
		} else {
			Debug.LogError ("Master volume not between 0 and 1");
			volume = 0.5f;
			return volume;
		}
	}

	/// <summary>
	/// Unlocks the level by setting each level key true ("1")
	/// </summary>
	/// <param name="level">Level.</param>
	public static void UnlockLevel (int level){
		if (level <= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // use 1 for true
		} else {
			Debug.LogError ("Level number not in the build settings. Is: " + level + 
				"    Should be below: " + (UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1).ToString());
		}
	
	}

	/// <summary>
	/// Determines if a given level is already unlocked.
	/// </summary>
	/// <returns><c>true</c> if the specified level is unlocked; otherwise, <c>false</c>.</returns>
	/// <param name="level">Level</param>
	public static bool IsLevelUnlocked (int level){
		int returnValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());

		if (returnValue == 0) {
			return false;
		} else if (returnValue == 1) {
				return true;
		} else {
			Debug.LogError ("Specific level (" + level + " has wrong return value: " + returnValue);
			return false;
		}
			
	}

	/// <summary>
	/// Sets the difficulty.
	/// </summary>
	/// <param name="difficulty">Difficulty should be between 1 and 3.</param>
	public static void SetDifficulty (float difficulty){
		if (difficulty > 0 && difficulty <= 3) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Trying to set difficulty not between 1 and 3. Setting to 1.");
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, 1);
		}
	}

	/// <summary>
	/// Gets the difficulty.
	/// </summary>
	/// <returns>The difficulty. Should be between 1 and 3.</returns>
	public static float GetDifficulty () {
		float difficulty = PlayerPrefs.GetFloat (DIFFICULTY_KEY);
		if (difficulty > 1 && difficulty <= 3) {
			return difficulty;
		} else {
			Debug.LogError ("Returned difficulty not between 1 and 3. Returning 1.");
			return 1;
		}

	}
}
