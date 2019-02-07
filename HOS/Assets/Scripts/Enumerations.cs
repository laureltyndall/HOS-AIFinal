﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

//References to determine whether the game is currently running.
public enum GameState
{
    None = 0,
    GameStarted = 1,
    GameInProgress = 2,
    GameOver = 3,
}

//References which character the player is currently using.
public enum Character
{
    None = 0,
    Alex = 1,
    Anne = 2,
}

//References to determine whether the player is able to progress further in the game.
public enum ProgressionCheckpoint
{
    None = 0,
    Introduction = 1,
    PassGate = 2,
    EnterHouse = 3,
    Kitchen = 4,
    LivingRoom = 5,
    HedgeMaze = 6,
    UndergroundTunnel = 7,
}

//References to determine the player's current save point.    
public enum SavePoint
{
    None = 0,
    Introduction = 1,
    Gate = 2,
    HouseGrounds = 3,
    HouseExterior = 4,
    HouseEntry = 5,
    Kitchen = 6,
    LivingRoom = 7,
    HedgeExterior = 8,
    HedgeInterior = 9,
    HedgeCenter = 10,
    UndergroundTunnelInitial = 11,
    UndergroundTunnelMaze = 12,
    UndergroundTunnelExit = 13,
}

//References to the items used by the inventory system
public enum InventoryItem
{
    Trowel = 0,
    Flashlight = 1,
    Worms = 2,
    Checklist = 3,
    Cheese = 4,
    Basket = 5,
    StarPiece = 6,
    Stick = 7,
    SecondList = 8,
}

public enum ItemStatus
{
    None = 0,
    NotAvailable = 1,
    Available = 2,
    InInventory = 3,
    Used = 4,
    Removed = 5,
}