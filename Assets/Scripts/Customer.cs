using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomerAgent))]
public class Customer : MonoBehaviour
{

    [SerializeField] float customerWaitTime, waitTimeLeft, minWaitTime = 15, maxWaitTime = 25;
    public bool waitingForFood = false, hasBeenFed = false, reachedCounter = false;

    private CustomerAgent ca;
    private GlobalTimer timer;

    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalTimer>();
        ca = this.GetComponent<CustomerAgent>();

        customerWaitTime = Random.Range(minWaitTime, maxWaitTime);
        waitTimeLeft = customerWaitTime;
    }

    private void Update()
    {
        if (waitingForFood)
        {
            waitTimeLeft -= 1 * Time.deltaTime;

            if (waitTimeLeft <= 0)
            {
                if (!hasBeenFed)
                {
                    timer.RemoveTime();
                    ca.Leave();
                    ca.agent.isStopped = false;
                    waitingForFood = false;
                }
            }

            if (hasBeenFed)
            {
                timer.AddTime();
                ca.agent.isStopped = false;
                ca.Leave();
            }
        }
    }

}
