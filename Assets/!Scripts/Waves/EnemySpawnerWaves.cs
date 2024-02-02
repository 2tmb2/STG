using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerWaves : MonoBehaviour {
	public int wave1;
	public int wave2;
	public int wave3;
	public int wave4;
	public int wave5;
	public int wave6;
	public int wave7;
	public GameObject[] SpawnPointOptions;
	public GameObject[] zombieTypes;
	public int startWait = 20;
	public int waveWait = 60;
	public int currentWave = 0;
	public int livingEnemies = 0;
	public Transform spawnPoint;
	private GameControllerWaves GC;
	private bool didWeStart = false;

	// Use this for initialization
	void Start () {
		GC = GetComponent<GameControllerWaves> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GC.shouldStart && !didWeStart) {
			didWeStart = true;
			StartCoroutine (WaveMaker ());
		}
	}

	public IEnumerator WaveMaker()
	{
		
		yield return new WaitForSeconds (startWait);
		currentWave = 1;
		for (int i = 0; i < wave1; i++) {
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate (whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}
		yield return new WaitForSeconds (waveWait);
		currentWave = 2;
		for (int i = 0; i < wave2; i++) {
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate (whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}
		yield return new WaitForSeconds (waveWait);
		currentWave = 3;
		for (int i = 0; i < wave3; i++) {
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate (whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}
		yield return new WaitForSeconds (waveWait);
		currentWave = 4;
		for (int i = 0; i < wave4; i++) {
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate(whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}
		yield return new WaitForSeconds (waveWait);
		currentWave = 5;
		for (int i = 0; i < wave5; i++) {
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate (whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}
		yield return new WaitForSeconds(waveWait);
		currentWave = 6;
		for (int i = 0; i < wave6; i++)
		{
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate(whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}
		yield return new WaitForSeconds(waveWait);
		currentWave = 7;
		for (int i = 0; i < wave7; i++)
		{
			var enemyNumber = Random.Range(0, zombieTypes.Length);
			var whichEnemy = zombieTypes[enemyNumber];
			int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
			var whichSpawn = SpawnPointOptions[spawnNumber];
			GameObject enemy = Instantiate(whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
			livingEnemies++;
		}

	}

	public void EnemyDied()
	{
		livingEnemies--;
	}
}
