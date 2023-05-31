using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{


    //public GameObject ItemP
    public TextMeshProUGUI ItemName;
    private BackPackController BackPack;
    private ChestController Chest;
    public int i;
    public int j;
    public TextMeshProUGUI AmountText;
    public int Amount;
    public GameObject CardPrefab;
    public GameObject DropButton;
    private Travel travel;
    [SerializeField] GameObject HomeButton;
    // Start is called before the first frame update
    void Start()
    {
        BackPack = FindObjectOfType<BackPackController>();
        travel = GetComponent<Travel>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        AmountText.text = Amount.ToString();
        if (Amount>1) 
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
             


        }
        else
        { transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            
        }

        

       
        if (transform.childCount==2)
        {
            BackPack.IsFull[i] = false;
        }


       if (HomeButton.activeSelf)
        {
            DropButton.SetActive(false);
        }
        else
        {
            DropButton.SetActive(true);
        }

    }

    public void DropItem()
    {
       // Vector3 CardPos = new Vector3(Chest.transform.position.x, Chest.transform.position.y, 0);
        if (Amount > 1)
        {
            Amount -= 1;
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
            
        }
        else
        {
            Amount -= 1;
            GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject);
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();

        }
    }

    public void UpgradeBackPack()
    {
        
    }
}
