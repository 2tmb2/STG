// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;
using System;
public class MoveTo : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    // Update is called once per frame
    void Update()
    {
        //if (!GC.didDie)
        //{
            this.GetComponent<NavMeshAgent>().SetDestination(goal.position);
        //}
    }
}