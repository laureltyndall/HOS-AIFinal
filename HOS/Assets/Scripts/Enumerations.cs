using System.Collections;
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

public enum SnakeState
{
    None = 0,
    Attack = 1,
    Recover = 2,
    Move = 3,
    Hurt = 4,
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
    MoveInChecklist = 3,
    Cheese = 4,
    Basket = 5,
    MarblePiece = 6,
    Stick = 7,
    MysteryChecklist = 8,
    SiblingLetter = 9,
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

public enum CursorType
{
    None = 0,
    Default = 1,
    Forward = 2,
    Backup = 3,
    LeftTurn = 4,
    RightTurn = 5,
    LookCloser = 6,
    PickUpItem = 7,
    Panoramic = 8,
    TurnAround = 9,
}