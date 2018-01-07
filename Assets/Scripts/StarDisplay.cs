using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum status {success, failure};

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private int stars;
	private Text display;


	void Start ()  {
		stars = 5;
		display = GetComponent<Text> ();
		display.text = stars.ToString ();
	}

	public void AddStar (int amount){
		stars += amount;
		display.text = stars.ToString ();
	}

	public status UseStar (int amount){
		if (amount > stars) {
			return status.failure;
		}
		stars -= amount;
		display.text = stars.ToString ();
		return status.success;
	}

	public void FlashRed(){
		display.color = Color.red;
		Invoke ("TextYellow", 0.3f);
	}

	private void TextYellow(){
		display.color = new Color32 (0xEB, 0xEC, 0x00, 0xFF);
	}
}
