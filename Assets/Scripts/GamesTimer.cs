using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamesTimer : MonoBehaviour {

	[Tooltip ("Time in seconds until level won")]
	public int levelTime;
	[Tooltip ("Should be a GameObject, like a Quad. Needs to be disabled on startup.")]
	public GameObject levelWonPopup;

	private Slider slider;
	private float startTime;
	private bool levelWon;
	private LevelManager levelManager;
	private MusicManager musicManager;
	 

	void Start (){
		slider = GetComponent<Slider> ();
		slider.value = 0f;
		startTime = Time.time;
		levelWon = false;
		levelManager = FindObjectOfType<LevelManager> ();
		musicManager = FindObjectOfType<MusicManager> ();
	}

	void Update (){

		float timeProgressed = Time.time - startTime;
		slider.value = SliderPos (timeProgressed);
		if (timeProgressed > levelTime && !levelWon) {
			levelWon = true;
			ShowWinText ();
		}
	}

	float SliderPos (float timeProgressed){
		return (timeProgressed / levelTime);
	}


	void ShowWinText(){
		levelWonPopup.SetActive (true);
		if (musicManager) {
			musicManager.PlayLevelWon ();
		} else {
			Debug.LogWarning ("No MusicManager present.");
		}
		Invoke ("LoadNextLevel", 5);
	}

	void LoadNextLevel (){
		levelWonPopup.SetActive (false);
		levelManager.LoadNextLevel ();
	}

}
