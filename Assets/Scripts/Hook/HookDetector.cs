using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{

    public GameObject player;

    public GameObject hookHolder;

    private bool hooked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hooked)
        {
            if (other.tag == "Food")
            {
                other.transform.position =
                    Vector3.MoveTowards(other.transform.position, hookHolder.transform.position, player.GetComponent<GrapplingHook>().hookTravelSpeed);

                hooked = true;
            }
        }

    }

}
