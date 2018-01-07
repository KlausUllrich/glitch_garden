using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;

	private Animator anim;

	public void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;
	}

	public void FireProjectile(){
		anim.SetBool ("isAttacking", true);
		if (anim) {
			anim.SetBool ("isAttacking", true);

		} else {
			Debug.LogWarning ("Anim not set " + GetInstanceID ());
		}
	}

	void OnTriggerEnter2D (Collider2D collider){
		if (collider.GetComponent<Health> ()) {
			if (collider.GetComponent<Attacker> ()) {
				collider.GetComponent<Health> ().DealDamage (damage);
				Destroy (gameObject);
			}
		}
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
