using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestSlot : MonoBehaviour
{
    public TextMeshProUGUI ItemName;
   
    private ChestController Chest;
    public int j;
    public TextMeshProUGUI AmountText;
    public int Amount;
    public GameObject CardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Chest = FindObjectOfType<ChestController>();


    }
    private void Update()
    {
        if (transform.childCount == 1)
        {
            Chest.IsFull[j] = false;
        }
    }








}
