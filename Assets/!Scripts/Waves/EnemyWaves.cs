using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{

	private GameControllerWaves GC;
	private EnemySpawnerWaves sponer;
	public int goldValue = 1;

	// Use this for initialization
	void Start()
	{
		GC = GameObject.FindObjectOfType<GameControllerWaves>();
		sponer = GameObject.FindObjectOfType<EnemySpawnerWaves>();
	}

	public void iDiedFrownyFace()
	{
		GC.AddGold(goldValue);
		sponer.EnemyDied();
	}
}
