using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndless : MonoBehaviour
{

	private GameControllerEndless GC;
	private InfiniteEnemySpawner sponer;
	public int goldValue = 1;

	// Use this for initialization
	void Start()
	{
		GC = GameObject.FindObjectOfType<GameControllerEndless>();
		sponer = GameObject.FindObjectOfType<InfiniteEnemySpawner>();
	}

	public void iDiedFrownyFace()
	{
		GC.AddGold(goldValue);
		sponer.EnemyDied();
	}
}
