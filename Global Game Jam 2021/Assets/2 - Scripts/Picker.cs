using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    public int id;
    public int inventoryId;

    public bool playerInside;

    private void Update()
    {
        if(playerInside)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Inventory.Instance.PickUp(id, inventoryId);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInside = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }
}
