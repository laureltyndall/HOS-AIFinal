using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class Player : MonoBehaviour 
{
    public ProgressionCheckpoint CurrentCheckpoint;
    public SavePoint CurrentSavepoint;
    public Character PlayerCharacter;
    public int PlayerHealth;
    public Dictionary<InventoryItem,Item> PlayerInventory = new Dictionary<InventoryItem, Item>();

	// Use this for initialization
	void Start () 
    {
		PlayerInventory = new Dictionary<InventoryItem, Item>();
	}
	
}
