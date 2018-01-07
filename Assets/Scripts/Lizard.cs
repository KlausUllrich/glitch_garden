using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {

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


		anim.SetBool ("isAttacking", true);
		attacker.Attack (obj);

	}
}
