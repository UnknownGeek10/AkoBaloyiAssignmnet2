using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Travel : MonoBehaviour

    
{
    private Slot slot;

    public GameObject NewItemToAdd;

    public GameObject ChestInventory;
    public GameObject ShopInventory;
    public GameObject HomeButton;
    public GameObject ShopButton;
    //public GameObject DropButton;
    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponent<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoShopping()
    {
        Shop();
    }


    public void ButtonClicked()
    {
        Home();
    }

    void Shop()
    {
        ChestInventory.SetActive(false);
        ShopInventory.SetActive(true);
        HomeButton.SetActive(true);
        ShopButton.SetActive(false);
        
        //DropButton.SetActive(true);


    }

    void Home()
    {
        ChestInventory.SetActive(true);
        ShopInventory.SetActive(false);
        HomeButton.SetActive(false);
        ShopButton.SetActive(true);
       // DropButton.SetActive(false);
        NewItemToAdd.SetActive(true);
       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
