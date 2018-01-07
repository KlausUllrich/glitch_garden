using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner mySpawner;

	void Start(){
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		animator = GetComponent<Animator> ();
		SetMySpawner ();
	}

	void Update (){
		if (AttackerIsAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	bool AttackerIsAheadInLane (){
		// No attackers in lane
		if (mySpawner.transform.childCount == 0) {
			return false;
		} 

		// attacker ahead of defender?
		foreach (Transform attacker in mySpawner.transform)
		{
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		// no attacker ahead of defender
		return false;
	}

	void SetMySpawner (){
		Spawner[] spawnerArray;
		spawnerArray = FindObjectsOfType<Spawner> ();
		foreach (Spawner toTestSpawner in spawnerArray) {
			if (toTestSpawner.transform.position.y == this.transform.position.y) {
				mySpawner = toTestSpawner;
				return;
			}
		}
		Debug.LogError ("Cannot find spawner in the lane.");
	}

	private void FireProjectile(){
		GameObject newShot = Instantiate (projectile) as GameObject;
		newShot.transform.parent = projectileParent.transform;
		newShot.transform.position = gun.transform.position;
		// Start seems to be required, otherwise the anim is not set!
		newShot.GetComponent<Projectile> ().Start ();
		newShot.GetComponent<Projectile>().FireProjectile ();
	}
}
