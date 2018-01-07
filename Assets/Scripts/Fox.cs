using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {


	private Animator anim;
	private Attacker attacker;

	void Start (){
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log (name + " collides with " + collider);

		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender>()) {
			return;
		}

		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("jumping");
			//Debug.Log ("jump!");
		} else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
