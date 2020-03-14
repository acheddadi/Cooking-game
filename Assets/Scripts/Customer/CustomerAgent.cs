using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAgent : MonoBehaviour
{

    public NavMeshAgent agent;

    private Customer customer;
    private CustomerDestination destination;

    private float counterTimer;

    void Start()
    {
        customer = this.GetComponent<Customer>();
        agent = this.GetComponent<NavMeshAgent>();
        destination = (CustomerDestination)FindObjectOfType(typeof(CustomerDestination));
        agent.SetDestination(destination.GetCounterDestination());
    }

    void Update()
    {
        if (counterTimer> 1.0f)
        {
            isAtCounter();
            counterTimer = 0.0f;
        }

        counterTimer += Time.deltaTime;
    }

    public void Leave()
    {
        agent.SetDestination(destination.GetLeaveDestination());
    }

    void isAtCounter()
    {
        if (!customer.reachedCounter)
        {
            if (Vector3.Distance(agent.transform.position, destination.GetCounterDestination()) <= 3)
            {
                agent.isStopped = true;
                customer.waitingForFood = true;
                customer.reachedCounter = true;
            }
        }
    }
}
