using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	public bool leftSide;
	public int hitpoints;

	private LevelManager levelManager;
	private HPDisplay hpDisplay;

	void Start (){
		levelManager = FindObjectOfType<LevelManager> ();
		hpDisplay = FindObjectOfType<HPDisplay> ();
	}

	void OnTriggerEnter2D (Collider2D collider){
		Destroy(collider.gameObject);

		if (leftSide) {
			hitpoints -= 10;
			hpDisplay.UpdateDisplay (hitpoints);
			if (hitpoints <= 0) {
				// Game Over
				levelManager.LoadLevel("98 Loose");
			}
		}
	}
}
