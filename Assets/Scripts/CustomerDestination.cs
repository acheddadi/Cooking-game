using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDestination : MonoBehaviour
{

    [SerializeField] private Transform counterDestination, leaveDestination;

    public Vector3 GetCounterDestination()
    {
        return counterDestination.position;
    }

    public Vector3 GetLeaveDestination()
    {
        return leaveDestination.position;
    }
}
