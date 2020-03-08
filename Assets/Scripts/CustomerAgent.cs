using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAgent : MonoBehaviour
{

    public Transform spawn;
    public Transform destination;
    NavMeshAgent agent;

    private Customer customer;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }

    void Update()
    {
        
    }

    public void CheckRemainingDistance()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {

        }
    }

    public IEnumerator Leave()
    {
        agent.SetDestination(spawn.position);
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

}
