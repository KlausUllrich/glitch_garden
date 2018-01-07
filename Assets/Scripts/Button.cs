using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public static GameObject selectedPrefab;
	public GameObject defender;

	private Button[] buttonArray;

	void Start (){
		GetComponent<SpriteRenderer> ().color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		if (!selectedPrefab) {
			selectedPrefab = defender;
		}
	}

	void OnMouseDown (){
		foreach (Button thisButton in buttonArray) {		
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedPrefab = defender;
	}
}
