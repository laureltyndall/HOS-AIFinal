using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
    public Dictionary<InventoryItem, Item> ItemsInInventory = new Dictionary<InventoryItem,Item>();
    public RawImage ThisPicture;
	// Use this for initialization
	void Start () 
    {
        Item NewItem = new Item();
        NewItem.ItemImage = ThisPicture;
        ItemsInInventory.Add(InventoryItem.Trowel,NewItem);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void AddInventoryItem()
    {
    }
    
    public void SelectItem()
    {

    }
    
    public void RemoveItem()
    {
    }

    public void ResetInventory()
    {
        ItemsInInventory.Clear();
    }
    
    private void IsItemInInventory()
    {
    }

    private void CanPlayerUseItem()
    {
    }
}
