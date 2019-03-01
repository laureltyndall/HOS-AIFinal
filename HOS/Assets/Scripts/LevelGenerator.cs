using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour 
{
    public const int MaxSegments = 4;
    public const int MaxLevelSize = 3;
    public GameObject MazeStartPosition;
    public GameObject[,] LevelArray = new GameObject[MaxLevelSize,MaxLevelSize];
    public GameObject[] MasterLevelSegmentArray = new GameObject[MaxSegments];
    private int NumberRow = 0;
    private int NumberCol = 0;
    private int GeneratedNumber = 0;
	// Use this for initialization
	void Start () 
    {
		GenerateMaze();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void GenerateMaze()
    {
        Transform t = MazeStartPosition.transform;
        t.position = new Vector3(0, 0, 0);
        float tempCoords;

        for (int i = 0; i < MaxLevelSize; i++)
        {
            for (int j = 0; j < MaxLevelSize; j++)
            {
                GenerateNumber();
                LevelArray[i, j] = MasterLevelSegmentArray[GeneratedNumber];
                tempCoords = t.position.x + MasterLevelSegmentArray[i].transform.localScale.x;
                t.position = new Vector3(tempCoords,t.position.y,t.position.z);
                if (j == MaxLevelSize - 1)
                {
                    tempCoords= t.position.z + MasterLevelSegmentArray[i].transform.localScale.z;
                    t.position = new Vector3(t.position.x, t.position.y, tempCoords);
                }
                GameObject G = GameObject.Instantiate(LevelArray[i, j]);
                G.transform.position = t.position;

            }
        }      
    }

    private void GenerateNumber()
    {
        GeneratedNumber = Random.Range(0,MaxSegments);   
    }
}
