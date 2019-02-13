using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
    public Dictionary<InventoryItem, Item> ItemsInInventory = new Dictionary<InventoryItem,Item>();
    public List<Button> InventoryButtonList = new List<Button>();
    public RawImage ThisPicture;
    public Item NewItem = new Item();
	// Use this for initialization
	void Start () 
    {

        NewItem.ItemImage = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<RawImage>();
        NewItem.ItemImage.enabled = false;
        ItemsInInventory.Add(InventoryItem.Trowel,NewItem);
	}
	
	// Update is called once per frame
	void Update()
    {
        if (ItemsInInventory.ContainsKey(InventoryItem.Trowel))
        {
             RawImage R = InventoryButtonList[0].GetComponent<RawImage>(); 
            R.texture = NewItem.ItemImage.texture;
            R.enabled = true;
        }
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
