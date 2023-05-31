using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private BackPackController BackPack;
    public GameObject ItemButton;
    public string ItemName;
    // public Item Item;
    


    void Start()
    {
        BackPack = FindObjectOfType<BackPackController>();
    }

    
    


    public void OnMouseDown()
    {
        
        
            for (int i = 0; i < BackPack.Slots.Length; i++)
            {
               if (BackPack.IsFull[i] == true && BackPack.Slots[i].transform.GetComponent<Slot>().Amount < 2)
                {
                    if (ItemName== BackPack.Slots[i].transform.GetComponentInChildren<Spawn>().ItemName)
                    {
                        Destroy(gameObject);
                        BackPack.Slots[i].GetComponent<Slot>().Amount += 1;
                        break;
                    }
                }
               else if (BackPack.IsFull[i] == false)
                {
                    BackPack.IsFull[i] = true;
                    Instantiate(ItemButton, BackPack.Slots[i].transform, false);
                    BackPack.Slots[i].GetComponent<Slot>().Amount += 1;
                    Destroy(gameObject);
                    break;
                }

            }
        
    }
   /* void Pickup()
    {
        ChestManager.Instance.Add(Item);
        Destroy(gameObject);

    }

    private void OnMouseDown()
    {
        Pickup();
    } */
}
