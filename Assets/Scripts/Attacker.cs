using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Creates a creature every seconds.")]
	public int appearsInSeconds;
	private float currentSpeed;
	private GameObject currentTarget;

	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime); 
		if (!currentTarget) {
			Animator anim = GetComponent<Animator> ();
			anim.SetBool ("isAttacking", false);
		}
	}


	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}

	/// <summary>
	/// Called by the Animator. Damages the current target.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void StrikeCurrentTarget (float damage){
		if (currentTarget) {
			currentTarget.GetComponent<Health> ().DealDamage (damage);
		}
	}

	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}
