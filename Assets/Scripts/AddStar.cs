using UnityEngine;
using System.Collections;

public class AddStar : MonoBehaviour {

	private StarDisplay starDisplay;

	void Start(){
		starDisplay = FindObjectOfType<StarDisplay> ();
	}

	public void AddStars (int amount){
		starDisplay.AddStar (amount);
	}
}
