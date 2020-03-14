using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float foodTravelSpeed;

    public static bool fired;
    public bool hooked;

    public float maxDistance;
    private float currentDistance;

    private void Update()
    {
        // Firing the hook
        if (Input.GetMouseButtonDown(1) && fired == false)
            fired = true;

        if (fired)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }
        
        if (fired && !hooked)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
        }

    }

    public void ReturnHook()
    {
        hook.transform.position = hookHolder.transform.position;
        fired = false;
    }
}
