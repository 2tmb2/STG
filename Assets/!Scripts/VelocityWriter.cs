using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityWriter : MonoBehaviour
{
    public Text VelocityText;
    private Rigidbody body;
    public Vector3 previous;
    public Vector3 current;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        current = transform.position;
        velocity = (current - previous).magnitude / Time.deltaTime;
        previous = transform.position;
        VelocityText.text = velocity.ToString();
    }
}
