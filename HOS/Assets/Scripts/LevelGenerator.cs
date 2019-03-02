using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour 
{
    public const int MaxLevelSections = 4;
    public const int LevelGridXSize = 3;
    public const int LevelGridYSize = 3;
    public GameObject MazeStartPosition;
    public GameObject[,] LevelGridArray = new GameObject[LevelGridXSize,LevelGridXSize];
    public GameObject[] LevelSectionArray = new GameObject[MaxLevelSections];
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

        for (int i = 0; i < LevelGridXSize; i++)
        {
            for (int j = 0; j < LevelGridYSize; j++)
            {
                GenerateNumber();
                LevelGridArray[i, j] = LevelSectionArray[GeneratedNumber];
                tempCoords = t.position.x + LevelSectionArray[i].transform.localScale.x;
                t.position = new Vector3(tempCoords,t.position.y,t.position.z);
                if (j == LevelGridXSize - 1)
                {
                    tempCoords= t.position.z + LevelSectionArray[i].transform.localScale.z;
                    t.position = new Vector3(t.position.x, t.position.y, tempCoords);
                }
                GameObject G = GameObject.Instantiate(LevelGridArray[i, j]);
                G.transform.position = t.position;

            }
        }      
    }

    private void GenerateNumber()
    {
        GeneratedNumber = Random.Range(0,MaxLevelSections);   
    }
}
