using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public abstract class Action : ScriptableObject
{
    public abstract void Act(StateController controller);
}