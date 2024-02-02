using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start) || Input.GetKeyDown(KeyCode.I))
        
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
