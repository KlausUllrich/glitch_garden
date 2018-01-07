using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;

	void Start (){
		currentHealth = maxHealth;
	}

	public void DealDamage (float damage){
		currentHealth -= damage;

		if (currentHealth <= 0) {
			// Object dies
			// should trigger animation, and animation should trigger die
			Die();

		}
	}

	public float GetHealth(){
		return currentHealth;
	}

	public void Die(){
		Destroy (gameObject);
	}
}
