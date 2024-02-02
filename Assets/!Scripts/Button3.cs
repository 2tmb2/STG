using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3 : MonoBehaviour
{
	void Update()
	{
		if (OVRInput.Get(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.H))
		{
			SceneManager.LoadScene("Waves");
		}
	}
}
