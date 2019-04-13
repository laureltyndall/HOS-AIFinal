using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class MouseManager
{
    public Transform SpawnPoint;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public List<Transform> m_WayPointList;
    private StateController controller;
    

    public void SetupAI(List<Transform> waypointList)
    {
        controller = m_Instance.GetComponent<StateController>();
        controller.SetupAI(true, waypointList);
    }
    
}
