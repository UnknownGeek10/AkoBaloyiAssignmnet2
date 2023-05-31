using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemAmount;
    public TextMeshProUGUI ItemPrice;
    public GameObject ItemToBuy;
    public int ItemQuantity;
    public TextMeshProUGUI BuyPriceText;

    private BackPackController BackPack;
    private Player player;

    [SerializeField]
   // private List<Item> initialItems;

    //private List<Item> dynamicInventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        
        BackPack = FindObjectOfType<BackPackController>();
        ItemName.text= ItemToBuy.GetComponent<Spawn>().ItemName;
        ItemImage.sprite= ItemToBuy.GetComponent<Image>().sprite;
        BuyPriceText.text= "$"+ItemToBuy.GetComponentInChildren<Spawn>().ItemPrice;

        // Instantiate all the items

        // Add items to dynamicInventory;
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemAmount.text= "Quantity: "+ ItemQuantity.ToString();
        
    }
    public void Buy()
    {
        for (int i = 0; i < BackPack.Slots.Length; i++)
        {
            if (BackPack.IsFull[i] == true && BackPack.Slots[i].transform.GetComponent<Slot>().Amount < 2 && player.Money >= ItemToBuy.GetComponentInChildren<Spawn>().ItemPrice && ItemQuantity > 0)
            {
                if (ItemName.text == BackPack.Slots[i].transform.GetComponentInChildren<Spawn>().ItemName)
                {
                    ItemQuantity -= 1;
                    BackPack.Slots[i].GetComponent<Slot>().Amount += 1;
                    player.Money -= ItemToBuy.GetComponentInChildren<Spawn>().ItemPrice;
                    break;
                }
            }
            else if (IsValidToBuy(i))
            {
                ItemQuantity -= 1;
                player.Money -= ItemToBuy.GetComponentInChildren<Spawn>().ItemPrice;
                //BackPack.Slots[i].GetComponent<Slot>().ItemName.text = ItemName.text;
                BackPack.IsFull[i] = true;
                Instantiate(ItemToBuy, BackPack.Slots[i].transform, false);
                BackPack.Slots[i].GetComponent<Slot>().Amount += 1;
                break;
            }

        }

    }

    private bool IsValidToBuy(int i)
    {
        var backPackHasSpace = BackPack.IsFull[i] == false;
        Debug.Log(ItemToBuy);
        var playerHasMoney = player.Money >= ItemToBuy.GetComponentInChildren<Spawn>().ItemPrice;
        var availableItem = ItemQuantity > 0;

        return backPackHasSpace && playerHasMoney && availableItem;
    }

    public void Sell()
    {
        for (int i = 0; i < BackPack.Slots.Length; i++)
        {
            if ( BackPack.Slots[i].transform.GetComponent<Slot>().Amount != 0)
            {
                if (ItemName.text == BackPack.Slots[i].transform.GetComponentInChildren<Spawn>().ItemName)
                {
                    ItemQuantity += 1;
                    BackPack.Slots[i].GetComponent<Slot>().Amount -= 1;
                    player.Money += ItemToBuy.GetComponentInChildren<Spawn>().ItemPrice;
                    if (BackPack.Slots[i].GetComponent<Slot>().Amount == 0)
                    {
                       // BackPack.Slots[i].GetComponent<Slot>().ItemName.text = string.Empty;
                        GameObject.Destroy(BackPack.Slots[i].transform.GetComponentInChildren<Spawn>().gameObject);
                    }

                    break;
                }
            
            }

        }

    }
}
