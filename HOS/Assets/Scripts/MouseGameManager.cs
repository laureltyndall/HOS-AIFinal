using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HOS;

public class MouseGameManager : MonoBehaviour
{
    public MouseManager[] Mice;
    public GameObject[] MousePrefabs;
    public List<Transform> wayPointsForAI;

    public void SpawnAllMice()
    {
        for (int i = 1; i < Mice.Length; i++)
        {
            Mice[i].m_Instance = Instantiate(MousePrefabs[0], Mice[0].SpawnPoint.position, Mice[0].SpawnPoint.rotation) as GameObject;
            Mice[i].SetupAI(wayPointsForAI);
        }
    }
    
    void Start()
    {
        SpawnAllMice();
        
    }
}
