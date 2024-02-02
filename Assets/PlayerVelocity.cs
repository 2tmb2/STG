using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVelocity : MonoBehaviour
{
    public Vector3 previous;
    public Vector3 current;
    public float PlayerVelocityValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current = transform.position;
        PlayerVelocityValue = (current - previous).magnitude / Time.deltaTime;
        previous = transform.position;
    }
}
