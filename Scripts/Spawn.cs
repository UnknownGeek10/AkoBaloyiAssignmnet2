using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    public GameObject ItemPrefab;
    public ItemPickup itemPickup;
    private ChestController Chest ;
    public string ItemName;
    public int ItemPrice;

    // Start is called before the first frame update
    void Start()
    {
        Chest = FindObjectOfType<ChestController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDroppedItem()

    {
        
       

        for (int j = 0; j < Chest.Slots.Length; j++)
        {
            if (Chest.IsFull[j] == true && Chest.Slots[j].transform.GetComponent<ChestSlot>().Amount < 1)
            {
                if (ItemName == Chest.Slots[j].transform.GetComponentInChildren<Spawn>().ItemName)
                {
                    Destroy(gameObject);
                    Chest.Slots[j].GetComponent<ChestSlot>().Amount += 1;
                    break;
                }
            }
            else if (Chest.IsFull[j] == false)
            {
                Chest.IsFull[j] = true;
                Instantiate(ItemPrefab, Chest.Slots[j].transform, false);
                Chest.Slots[j].GetComponent<ChestSlot>().Amount += 1;
                Destroy(gameObject);
                break;
            }

        }
        Debug.Log("Card placed in Chest");

        //Instantiate(ItemPrefab,CardPos, Quaternion.identity);
    }
}
