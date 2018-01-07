using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] musicForEachLevel;
	public AudioClip levelWon;
	private AudioSource music;
	private int sceneIndex;

	void Awake (){
		GameObject.DontDestroyOnLoad(gameObject);
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Start () {
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		music = GetComponent<AudioSource> ();
		music.clip = musicForEachLevel [sceneIndex];
		music.Play ();

	}


	void OnSceneLoaded (Scene scene, LoadSceneMode mode){
		//sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		sceneIndex = scene.buildIndex;
		if (! musicForEachLevel [sceneIndex]) {
			Debug.Log ("No Music in Clip: " + sceneIndex);
		} else {
			music.Stop ();
			music.clip = musicForEachLevel [sceneIndex];
			music.loop = true;
			music.Play ();
		}

	}

	public void SetVolume (float volume){
		if (volume >= 0 && volume <= 1) {
			music.volume = volume;
		} else {
			Debug.LogError ("Volume not set between 0 and 1.");
		}
	}

	public void PlayLevelWon(){
		if (! levelWon) {
			Debug.Log ("No Music for level won!");
		} else {
			Debug.Log ("Playing level won clip");
			music.Stop ();
			music.clip = levelWon;
			music.loop = true;
			music.Play ();
		}
	}

}
