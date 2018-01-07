using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadAfterSplash;

	void Start (){
		if (autoLoadAfterSplash <= 0) {
			//Debug.LogWarning ("AutoLoad needs to be 0 or higher.");
		} else {
			Debug.Log ("Loading next level in " + autoLoadAfterSplash + "sec.");
			Invoke ("LoadNextLevel", autoLoadAfterSplash);
		}

	}
	public void LoadLevel (string level){
		StartCoroutine(LoadAsyncScene(level));
	}


	public void LoadNextLevel (){
		int index = SceneManager.GetActiveScene ().buildIndex + 1;
		Debug.Log ("Loading level " + index + "...");
		StartCoroutine(LoadAsyncSceneIndex(index));
	}

	public void Quit (){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
		


	IEnumerator LoadAsyncScene(string level)
	{
		// The Application loads the Scene in the background at the same time as the current Scene.
		//This is particularly good for creating loading screens. You could also load the scene by build //number.
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

	IEnumerator LoadAsyncSceneIndex(int index){
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (index);
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}