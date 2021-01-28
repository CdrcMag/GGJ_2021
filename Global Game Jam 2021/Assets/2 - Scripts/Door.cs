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
            StartCoroutine(IMoveDoor());
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

    IEnumerator IMoveDoor()
    {
        while(transform.position.y > -3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.001f, transform.position.z);
            yield return null;
        }
    }


}
