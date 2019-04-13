using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public abstract class Decision : ScriptableObject
{
    public abstract bool Decide(StateController controller);
}