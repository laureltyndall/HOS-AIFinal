using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class MouseManager
{
    public Transform m_SpawnPoint;
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public int m_Wins;
    [HideInInspector] public List<Transform> m_WayPointList;

    private GameObject m_CanvasGameObject;
    private StateController m_StateController;

    public void SetupAI(List<Transform> waypointList)
    {
        m_StateController = m_Instance.GetComponent<StateController>();
        m_StateController.SetupAI(true, waypointList);

        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();
        
    }

    

}
