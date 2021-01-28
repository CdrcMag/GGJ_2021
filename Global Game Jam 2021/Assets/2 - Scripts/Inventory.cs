using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    /* Item 0 : Clé
     * Item 1 : Balais
     * Item 2 : Manche
     * Item 3 : C_BalaisComplet
     * 
     * 
     *
     */

    private void Awake()
    {
        Instance = this;
    }

    public Pickable[] pickables = new Pickable[3];

    public Pickable[] currentInventory = new Pickable[5];

    public int c_A, c_B;

    [ContextMenu("Combine")]
    public void Combine()
    {

    }
    


    public void PickUp(int objId, int whereToPut)
    {
        if(objId < pickables.Length)
        {
            pickables[objId].isUnlocked = true;
            currentInventory[whereToPut] = pickables[objId];
        }
        else
        {
            Debug.LogWarning("Attention, mauvais ID");
        }
        
    }

    public bool GetMatchingKey(Pickable key)
    {
        for(int i = 0; i < currentInventory.Length; i++)
        {
            if (key == currentInventory[i])
                return true;
        }

        return false;
    }


}
