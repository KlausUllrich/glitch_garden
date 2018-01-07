using UnityEngine;
using System.Collections;

public class LoadVolume : MonoBehaviour {

	private MusicManager musicManager;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			musicManager.SetVolume (PlayerPrefsManager.GetMasterVolume ());
		} else {
			Debug.LogWarning ("No MusicManager present; cannot set volume.");
		}
	}
	

}
