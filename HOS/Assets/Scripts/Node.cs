﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class Node
{
    #region Member Variables
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;

    #region Default Constructor
    public Node (bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
    #endregion

    #endregion

}

