using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePopUp : MonoBehaviour
{
    public GameObject player;
    public GameObject pannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Four) || Input.GetKeyDown(KeyCode.O))
        {
            if (pannel.activeInHierarchy == false)
            {
                pannel.transform.position = player.transform.position;
                pannel.SetActive(true);
            }
            else if (pannel.activeInHierarchy == true)
            {
                pannel.SetActive(false);
            }

        }
    }
}
