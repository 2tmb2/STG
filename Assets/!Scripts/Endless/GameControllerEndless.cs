using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerEndless : MonoBehaviour {

	public int currentGold = 0;
	public Damager myHealth;
	private InfiniteEnemySpawner spawner;
	public Text goldText;
	private StartWinLoseRestart swlr;
	public bool didDie = false;
	private bool didWin = false;
	public bool shouldStart = false;

	// Use this for initialization
	void Start () {
        spawner = GetComponent<InfiniteEnemySpawner>();
		swlr = GetComponent<StartWinLoseRestart> ();
		currentGold = 15;
	}
	
	// Update is called once per frame
	void Update () {
		goldText.text = currentGold.ToString();
		if (myHealth.currentHealth <= 0 && !didDie && !didWin) {
			swlr.TriggerLose ();
			didDie = true;
		}
	}

	public void AddGold(int goldAmt){
		currentGold += goldAmt;
	}
	public void RemoveGold(int goldAmt)
    {
		currentGold -= goldAmt;
    }
	public int CheckGold(){
		return currentGold;
	}
	public void LetUsBegin()
	{
		if (!shouldStart) {
			shouldStart = true;
		}
	}
}
