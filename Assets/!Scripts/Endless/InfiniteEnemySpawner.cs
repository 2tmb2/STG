using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteEnemySpawner : MonoBehaviour
{

	public GameObject[] zombieTypes;
	public GameObject[] SpawnPointOptions;
	public int startWait = 0;
	public int waveWait = 30;
	public int currentWave = 0;
	public int livingEnemies = 0;
	private GameControllerEndless GC;
	public bool didWeStart = false;
	public int NumberOfWaveEnemies;
	public int NumberOfStartWaveEnemies;
	public bool gameOver;
	public int WaveIncrease;


	// Use this for initialization


	void Start()
	{
		GC = GetComponent<GameControllerEndless>();
	}

	// Update is called once per frame
	void Update()
	{
		if (GC.shouldStart && !didWeStart)
		{
			didWeStart = true;
			StartCoroutine(WaveMaker());
		}
	}

	public IEnumerator WaveMaker()
	{

		yield return new WaitForSeconds(startWait);
		NumberOfWaveEnemies = NumberOfStartWaveEnemies;
		while (!gameOver)
		{
			for (int i = 0; i < NumberOfWaveEnemies; i++)
			{
				var enemyNumber = Random.Range(0, zombieTypes.Length);
				var whichEnemy = zombieTypes[enemyNumber];
				int spawnNumber = Random.Range(0, SpawnPointOptions.Length);
				var whichSpawn = SpawnPointOptions[spawnNumber];
				GameObject enemy = Instantiate(whichEnemy, whichSpawn.transform.position, Quaternion.identity) as GameObject;
				livingEnemies++;
			}
			NumberOfWaveEnemies = NumberOfWaveEnemies + WaveIncrease;
			yield return new WaitForSeconds(waveWait);
		}



	}

	public void EnemyDied()
	{
		livingEnemies--;
	}
}
