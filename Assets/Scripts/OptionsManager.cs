using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
	}
	
	public void SafeAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel ("01 Start Menu");
	}

	public void ResetToDefault(){
		volumeSlider.value = 0.75f;
		difficultySlider.value = 1f;
	}

	public void Update (){
		if (musicManager != null) {
			musicManager.SetVolume (volumeSlider.value);
		}
	}
}
