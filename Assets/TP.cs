using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject playercamera;
    public GameObject tppoint;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.N))
        {
            playercamera.transform.position = tppoint.transform.position;
        }
    }
}
