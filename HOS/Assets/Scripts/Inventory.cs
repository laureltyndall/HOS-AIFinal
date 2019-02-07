using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
    public Dictionary<InventoryItem, Item> ItemsInInventory = new Dictionary<InventoryItem,Item>();
    
	// Use this for initialization
	void Start () {
		
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
