using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class Player : MonoBehaviour
{
    public ProgressionCheckpoint CurrentCheckpoint;
    public SavePoint CurrentSavepoint;
    public string PlayerName;
    public Character PlayerCharacter;
    public int PlayerHealth;
    public Dictionary<InventoryItem,Item> PlayerInventory = new Dictionary<InventoryItem, Item>();

	// Use this for initialization
	void Start () 
    {
        GameObject.DontDestroyOnLoad(this);
		PlayerInventory = new Dictionary<InventoryItem, Item>();
	}
	
}
