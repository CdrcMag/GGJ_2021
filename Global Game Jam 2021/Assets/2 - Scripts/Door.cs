using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool playerInside;

    public Pickable key;


    private void Update()
    {
        if (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        if (Inventory.Instance.GetMatchingKey(key) && key != null)
        {
            print("Door opens");
        }
        else
        {
            print("Door nope");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
