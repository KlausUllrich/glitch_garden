using UnityEngine;
using System.Collections;

public class spawnDefenders : MonoBehaviour {

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start(){
		defenderParent = GameObject.Find ("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}

		starDisplay = FindObjectOfType<StarDisplay> ();
	}
	void OnMouseDown(){
		int cost = Button.selectedPrefab.GetComponent<Defender> ().cost;

		if (starDisplay.UseStar (cost) == status.success) {
			GameObject newDefender;
			newDefender = Instantiate (Button.selectedPrefab, CalculateWorldPointOnMouseClick (), Quaternion.identity) as GameObject;
			newDefender.transform.parent = defenderParent.transform;
		} else {
			starDisplay.FlashRed ();
		}
	}

	Vector3 CalculateWorldPointOnMouseClick() {
		Vector3 point;
		point = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
		point.x = Mathf.Round (point.x);
		point.y = Mathf.Round (point.y);
		return (new Vector3(point.x, point.y, -0.1f));
	}
}
