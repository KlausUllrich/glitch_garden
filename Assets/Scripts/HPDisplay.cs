using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPDisplay : MonoBehaviour {

	public Text hpDisplay;

	void Start (){
		hpDisplay = GetComponent<Text> ();
	}

	public void UpdateDisplay(int hp){
		hpDisplay.text = hp.ToString () + "%";
	}
}
