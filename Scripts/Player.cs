using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public List<GameObject>Pickupitems= new List<GameObject> ();
    public int Money;
    public TextMeshProUGUI Wallet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wallet.text = "$" + Money; 
        
    }
    /*private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        Pickupitems.Add(gameObject);
    }*/
}
