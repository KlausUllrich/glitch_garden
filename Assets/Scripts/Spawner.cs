using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public void Spawn (GameObject myGameObject){
		GameObject newAttacker;
		newAttacker = Instantiate (myGameObject, transform.position, Quaternion.identity) as GameObject;
		newAttacker.transform.parent = transform;
	}

}
