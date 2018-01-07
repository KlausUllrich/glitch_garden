using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;

	private Image image;
	private Color imageColor;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		imageColor = image.color;
	}

	void Update (){
		if (Time.timeSinceLevelLoad < fadeInTime) {
			// Fade in
			float percentFaded = (fadeInTime - Time.timeSinceLevelLoad)/fadeInTime;
			imageColor.a = percentFaded;
			image.color = imageColor;
		} else {
			gameObject.SetActive (false);
		}
	}
		
		

}
