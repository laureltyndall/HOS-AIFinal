using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using HOS;

[Serializable]
public class MouseGameManager : MonoBehaviour
{

    [HideInInspector] public GameObject mouse;
    public List<Transform> wayPointsForAI;
    private StateController sc;
   
    public void SetupAI(List<Transform> wayPointList)
    {
        sc = mouse.GetComponent<StateController>();
        sc.SetupAI(true, wayPointList);


    }
}
