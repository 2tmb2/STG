using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerWaves : MonoBehaviour
{

	public int goldATM = 0;
	public Damager myHealth;
	private EnemySpawnerWaves spawner;
	public Text goldText;
	private StartWinLoseRestart swlr;
	public bool didDie = false;
	private bool didWin = false;
	public bool shouldStart = false;

	// Use this for initialization
	void Start()
	{
		goldATM = 15;
		spawner = GetComponent<EnemySpawnerWaves>();
		swlr = GetComponent<StartWinLoseRestart>();
	}

	// Update is called once per frame
	void Update()
	{
		goldText.text = goldATM.ToString();
		if (myHealth.currentHealth <= 0 && !didDie && !didWin)
		{
			swlr.TriggerLose();
			didDie = true;
		}
		else 
		{
			if (CheckWin () && !didWin) 
			{
				swlr.TriggerWin ();
                didWin = true;
			}
        }
	}


		public bool CheckWin()
		{
			EnemyWaves[] liveEnemies = GameObject.FindObjectsOfType<EnemyWaves> ();
			if (spawner.currentWave >= 7 && liveEnemies.Length<=0){//spawner.livingEnemies <= 1) {
				return true;
			} else {
				return false;
			}
		}
	public void AddGold(int goldAmt)
	{
		goldATM += goldAmt;
	}

	public int CheckGold()
	{
		return goldATM;
	}
	public void LetUsBegin()
	{
		if (!shouldStart)
		{
			shouldStart = true;
		}
	}
}
