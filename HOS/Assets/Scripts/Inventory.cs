using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HOS;

public class Inventory : MonoBehaviour 
{
    public GameManager Manager;
    public Dictionary<InventoryItem, Item> ItemsInInventory = new Dictionary<InventoryItem,Item>();
    public List<Button> InventoryButtonList = new List<Button>();
    public Image ThisPicture;
    public Item NewItem = new Item();
	// Use this for initialization
	void Start () 
    {
        GameObject.DontDestroyOnLoad(this);

        Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        #region Create Inventory Items
        NewItem.ItemImage = GameObject.FindGameObjectWithTag("FlashlightSprite").GetComponent<Image>(); // Find Item Image
        NewItem.ItemImage.enabled = false; //Disable Item Image
        NewItem.ItemID = InventoryItem.Flashlight; //Add Item ID
        NewItem.Status = ItemStatus.Available; //Add Item Status
        ItemsInInventory.Add(InventoryItem.Flashlight,NewItem); //Add Item to inventory
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("TrowelSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.Trowel;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.Trowel,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("BasketSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.Basket;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.Basket,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("CheeseSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.Cheese;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.Cheese,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("MarblePieceSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.MarblePiece;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.MarblePiece,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("Move-InChecklistSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.MoveInChecklist;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.MoveInChecklist,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("MysteryChecklistSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.MysteryChecklist;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.MysteryChecklist,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("SiblingLetterSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.SiblingLetter;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.SiblingLetter,NewItem);
        NewItem = new Item();

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("StickSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.Stick;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.Stick,NewItem);       
        NewItem = new Item();


        NewItem.ItemImage = GameObject.FindGameObjectWithTag("WormsSprite").GetComponent<Image>();
        NewItem.ItemImage.enabled = false;
        NewItem.ItemID = InventoryItem.Worms;
        NewItem.Status = ItemStatus.Available;
        ItemsInInventory.Add(InventoryItem.Worms,NewItem);
        NewItem = new Item();

        #endregion

       GameObject InventoryPanel = GameObject.FindGameObjectWithTag("InventoryPanel");
       InventoryPanel.SetActive(false);
	}

    public void AddInventoryItem(InventoryItem CurrentItem)
    {
        if (CurrentItem == InventoryItem.Basket && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Basket))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.Basket, ItemsInInventory[InventoryItem.Basket]);
        }
        else if (CurrentItem == InventoryItem.Cheese && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Cheese))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.Cheese, ItemsInInventory[InventoryItem.Cheese]);
        }
        else if (CurrentItem == InventoryItem.Flashlight && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Flashlight))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.Flashlight, ItemsInInventory[InventoryItem.Flashlight]);
        }
        else if (CurrentItem == InventoryItem.MarblePiece && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.MarblePiece))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.MarblePiece, ItemsInInventory[InventoryItem.MarblePiece]);
        }
        else if (CurrentItem == InventoryItem.MoveInChecklist && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.MoveInChecklist))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.MoveInChecklist, ItemsInInventory[InventoryItem.MoveInChecklist]);
        }
        else if (CurrentItem == InventoryItem.MysteryChecklist && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.MysteryChecklist))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.MysteryChecklist, ItemsInInventory[InventoryItem.MysteryChecklist]);
        }
        else if (CurrentItem == InventoryItem.SiblingLetter && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.SiblingLetter))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.SiblingLetter, ItemsInInventory[InventoryItem.SiblingLetter]);
        }
        else if (CurrentItem == InventoryItem.Stick && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Stick))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.Stick, ItemsInInventory[InventoryItem.Stick]);
        }
        else if (CurrentItem == InventoryItem.Trowel && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Trowel))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.Trowel, ItemsInInventory[InventoryItem.Trowel]);
        }
        else if (CurrentItem == InventoryItem.Worms && !Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Worms))
        {
            Manager.CurrentPlayer.PlayerInventory.Add(InventoryItem.Worms, ItemsInInventory[InventoryItem.Worms]);
        }
    }
    
    public void SelectItem(InventoryItem CurrentItem)
    {
        if (CurrentItem == InventoryItem.Basket)
        {
        }
        else if (CurrentItem == InventoryItem.Cheese)
        {
        }
        else if (CurrentItem == InventoryItem.Flashlight)
        {
        }
        else if (CurrentItem == InventoryItem.MarblePiece)
        {
        }
        else if (CurrentItem == InventoryItem.MoveInChecklist)
        {
        }
        else if (CurrentItem == InventoryItem.MysteryChecklist)
        {
        }
        else if (CurrentItem == InventoryItem.SiblingLetter)
        {

        }
        else if (CurrentItem == InventoryItem.Stick)
        {

        }
        else if (CurrentItem == InventoryItem.Trowel)
        {
        }
        else if (CurrentItem == InventoryItem.Worms)
        {
        }
    }
    
    public void RemoveItem(InventoryItem CurrentItem)
    {
        if (CurrentItem == InventoryItem.Basket)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.Basket);
        }
        else if (CurrentItem == InventoryItem.Cheese)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.Cheese);
        }
        else if (CurrentItem == InventoryItem.Flashlight)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.Flashlight);
        }
        else if (CurrentItem == InventoryItem.MarblePiece)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.MarblePiece);
        }
        else if (CurrentItem == InventoryItem.MoveInChecklist)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.MoveInChecklist);
        }
        else if (CurrentItem == InventoryItem.MysteryChecklist)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.MysteryChecklist);
        }
        else if (CurrentItem == InventoryItem.SiblingLetter)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.SiblingLetter);
        }
        else if (CurrentItem == InventoryItem.Stick)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.Stick);
        }
        else if (CurrentItem == InventoryItem.Trowel)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.Trowel);
        }
        else if (CurrentItem == InventoryItem.Worms)
        {
            Manager.CurrentPlayer.PlayerInventory.Remove(InventoryItem.Worms);
        }
    }

    public void ResetInventory()
    {
        ItemsInInventory.Clear();
    }

    public void FindButtons()
    {
        InventoryButtonList = new List<Button>();

        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B1").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B2").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B3").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B4").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B5").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B6").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B7").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B8").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B9").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B10").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B11").GetComponent<Button>());
        InventoryButtonList.Add(GameObject.FindGameObjectWithTag("B12").GetComponent<Button>());
        ActivateMenu();
       GameObject InventoryPanel = GameObject.FindGameObjectWithTag("InventoryPanel");
       InventoryPanel.SetActive(false);
    }
  
    private void UpdateItems()
    {
        int counter = 0;

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Basket))
        {
            Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.Basket].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Cheese))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.Cheese].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }  
  
        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Flashlight))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.Flashlight].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        } 

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.MarblePiece))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.MarblePiece].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.MoveInChecklist))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.MoveInChecklist].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.MysteryChecklist))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.MysteryChecklist].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.SiblingLetter))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.SiblingLetter].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Stick))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.Stick].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Trowel))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.Trowel].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }

        if (Manager.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Worms))
        {
             Image R = InventoryButtonList[counter].GetComponent<Image>();
            R.color = Color.white; 
            R.sprite = Manager.CurrentPlayer.PlayerInventory[InventoryItem.Worms].ItemImage.sprite;
            R.enabled = true;
            counter += 1;
        }   
    }
    
    private bool IsItemInInventory(Item i)
    {
        foreach (KeyValuePair <InventoryItem, Item> item in Manager.CurrentPlayer.PlayerInventory)
        {
            if (i.ItemID == item.Key)
            {
                return true;
            }
        }
        return false;
    }

    public void ActivateMenu()
    {
        foreach (Button B in InventoryButtonList)
        {
             Image R = B.GetComponent<Image>();
            R.color = Color.black; 
            R.enabled = true;
        }
        UpdateItems();
    }

    private void CanPlayerUseItem(Item i)
    {
        if (IsItemInInventory(i))
        {
            if (i.ItemID  == InventoryItem.Basket)
            {
            }
            else if (i.ItemID == InventoryItem.Cheese)
            {
            }   
            else if (i.ItemID  == InventoryItem.Flashlight)
            {
            }
            else if (i.ItemID  == InventoryItem.MarblePiece)
            {
            }
            else if (i.ItemID  == InventoryItem.MoveInChecklist)
            {
            }
            else if (i.ItemID  == InventoryItem.MysteryChecklist)
            {
            }
            else if (i.ItemID  == InventoryItem.SiblingLetter)
            {

            }
            else if (i.ItemID  == InventoryItem.Stick)
            {

            }
            else if (i.ItemID  == InventoryItem.Trowel)
            {
            }
            else if (i.ItemID  == InventoryItem.Worms)
            {
            }
        }
    }
}
