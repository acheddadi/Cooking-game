using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    [SerializeField]
    float customerWaitTime;
    float waitTimeLeft;
    float minWaitTime = 15;
    float maxWaitTime = 25;
    bool waitingForFood = false;
    bool hasBeenFed = false;

    public Transform spawnPoint;
    public Transform counterPoint;

    private CustomerAgent ca;
    private GlobalTimer timer;

    private void Start()
    {
        customerWaitTime = Random.Range(minWaitTime, maxWaitTime);
        waitTimeLeft = customerWaitTime;
    }

    private void Update()
    {
        if (waitingForFood == true)
        {
            waitTimeLeft -= 1 * Time.deltaTime;

            if (waitTimeLeft <= 0)
            {
                timer.RemoveTime();
                StartCoroutine(ca.Leave());
            }

            if (hasBeenFed == true)
            {
                timer.AddTime();
                StartCoroutine(ca.Leave());
            }
        }
    }

}
