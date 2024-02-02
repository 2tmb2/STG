using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartWinLoseRestart : MonoBehaviour {
	[Header("Events at game start")]
	public UnityEvent startEvents;

	[Header("Win Events")]
	public UnityEvent winEvents;

	[Header("Lose Events")]
	public UnityEvent loseEvents;

	[Header("Restart settings")]
	public float restartDelay = 1f;
	public UnityEvent restartEvents;
	private bool restartRequested = false;


	void Start () {
		startEvents.Invoke ();
	}

	public void TriggerWin() {
		winEvents.Invoke ();
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		foreach (GameObject enemy in enemies)
		GameObject.Destroy(enemy);
	}

	public void TriggerLose() {
		SceneManager.LoadScene("Lose");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		foreach (GameObject enemy in enemies)
		GameObject.Destroy(enemy);
	}

	public void Restart() {
		if (!restartRequested) {
			restartRequested = true;
			StartCoroutine (RestartDelay ());
		}
	}

	private IEnumerator RestartDelay() {
		restartEvents.Invoke ();
		yield return new WaitForSeconds (restartDelay);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		yield break;
	}

}
