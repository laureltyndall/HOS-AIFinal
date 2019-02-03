using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public enum GameState
{
    None = 0,
    GameStarted = 1,
    GameInProgress = 2,
    GameOver = 3,
}

public enum Character
{
    None = 0,
    Alex = 1,
    Anne = 2,
}

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
