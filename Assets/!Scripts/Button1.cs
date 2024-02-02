using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour
{
	void Update()
	{
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.G))
		{
			SceneManager.LoadScene("Endless");
		}
	}
}