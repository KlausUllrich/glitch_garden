using UnityEngine;
using System.Collections;

public class SpawnDirector : MonoBehaviour {

	[Tooltip ("Enter all possible enemy prefabs.")]
	public GameObject[] availableEnemies;

	private Spawner[] spawner;


	void Start () {
		spawner = GetComponentsInChildren<Spawner>();

	}
	

	void Update () {
		// ask each frame if an available Enemie gets a chance to spawn
		// then spawn randomly on one spawner
		foreach (GameObject thisAttacker in availableEnemies){
			if (IsTimeToSpawn (thisAttacker)) {
				SpawnEnemy (thisAttacker);
			}
		}
	}

	bool IsTimeToSpawn (GameObject thisAttacker)
	{
		float meanSpawnDelay = thisAttacker.GetComponent<Attacker> ().appearsInSeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		float threshold = spawnsPerSecond * Time.deltaTime * Time.timeSinceLevelLoad / 40;
		//Debug.Log ("Attacker: " + thisAttacker.name + "    spawns per second: " + spawnsPerSecond + "     threshold: " + threshold);
		return (Random.value < threshold);
	}

	void SpawnEnemy (GameObject thisAttacker){
		int numberOfAvailableSpawner = spawner.GetLength (0) ;
		int selectedSpawner = Random.Range (0, numberOfAvailableSpawner);
		spawner [selectedSpawner].Spawn (thisAttacker);
	}
}
