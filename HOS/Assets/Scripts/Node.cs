using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class Node
{
    #region Member Variables
    public bool walkable;
    public Vector3 worldPosition;

    #region Default Constructor
    public Node (bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
    }
    #endregion

    #endregion

}

