using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHolderToInventory : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            // Where we can set to add to inventory, right now it'll just destroy game object.
            Destroy(other.gameObject);
        }
    }

}
