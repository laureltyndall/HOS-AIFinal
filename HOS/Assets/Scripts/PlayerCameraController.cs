using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace HOS
{ 
public class PlayerCameraController : MonoBehaviour
{
    public GameObject CurrentPlayer;
        public GameManager ManagerScript;
    public float RotateTime = 0.2f;
    public List<GameObject> WaypointList = new List<GameObject>();
    public GameObject CurrentWaypoint;
    public List<Texture2D> CursorList;
    public Camera MainCamera;
    public CursorType CurrentCursor = CursorType.Default;
    private Scene CurrentScene;

    public bool CanUturn = false;
    public bool CanOrbit = false;
    public bool CanLeftTurn = false;
    public bool CanRightTurn = false;
    public bool CanForward = false;
    public bool CanBackup = false;

    // Use this for initialization
    void Start () 
    {
		FindWaypointList();
        CurrentScene = SceneManager.GetActiveScene();
            GameObject GO = GameObject.FindGameObjectWithTag("GameController");
            ManagerScript = GO.GetComponent<GameManager>();

            FindCharacter();


        //    if (CurrentScene.name == "Intro")
        //{

        //    CurrentPlayer.transform.position = WaypointList[0].transform.position;
        //    CurrentWaypoint = WaypointList[0];
        //    CanUturn = true;
        //    CanForward = true;
        //}

    }

    void Update()
    {
            if (CurrentPlayer == null)
            {
                FindCharacter();

                if (CurrentScene.name == "Intro")
                {
                    MainCamera = Camera.main;
                    CurrentPlayer.transform.position = WaypointList[0].transform.position;
                    CurrentWaypoint = WaypointList[0];
                    CanUturn = true;
                    CanForward = true;
                }
            }
        if(Input.GetMouseButtonDown(0))
        {
            MovePlayer();
        }
    }

    public void FindWaypointList()
    {
        GameObject TempObj = GameObject.FindGameObjectWithTag("WaypointList");
        WaypointList = new List<GameObject>();
        foreach (Transform t in TempObj.transform)
        {
            WaypointList.Add(t.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (CurrentScene.name == "Intro")
        {
            if (CurrentCursor == CursorType.Forward)
            {
                if (CanForward)
                {
                    if (CurrentWaypoint == WaypointList[0])
                    {
                        CurrentPlayer.transform.position = WaypointList[1].transform.position;
                        CurrentWaypoint = WaypointList[1];
                    }
                    else if (CurrentWaypoint == WaypointList[2])
                    {
                        CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        CurrentWaypoint = WaypointList[0];
                     //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    //else if (CurrentWaypoint == WaypointList[1])
                    //{
                    //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                    //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                    //    CurrentWaypoint = WaypointList[2];
                    //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                    //}

                }
            }

            if (CurrentCursor == CursorType.TurnAround)
            {
                MovePlayerUturn();

            }
            if (CurrentCursor == CursorType.Backup)
            {
                if (CurrentScene.name == "Intro")
                {
                    if (CurrentWaypoint == WaypointList[2])
                    {
                        CurrentPlayer.transform.position = WaypointList[1].transform.position;
                        CurrentWaypoint = WaypointList[1];

                    }
                }

            }
        }
    }

    public void MovePlayer()
    {
        if (CurrentScene.name == "Intro")
        {
            if (CurrentCursor == CursorType.Forward)
            {
                if (CanForward)
                {
                    if (CurrentWaypoint == WaypointList[0])
                    {
                        CurrentPlayer.transform.position = WaypointList[1].transform.position;
                        CurrentWaypoint = WaypointList[1];
                        CanUturn = true;
                        CanOrbit = true;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = false;
                        CanBackup = false;
}
                    //else if (CurrentWaypoint == WaypointList[2])
                    //{
                    //    CurrentPlayer.transform.position = WaypointList[0].transform.position;
                    //    CurrentWaypoint = WaypointList[0];
                    //    //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    //}
                    //else if (CurrentWaypoint == WaypointList[1])
                    //{
                    //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                    //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                    //    CurrentWaypoint = WaypointList[2];
                    //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                    //}

                }
            }

            if (CurrentCursor == CursorType.TurnAround)
            {
                MovePlayerUturn();

            }
            if (CurrentCursor == CursorType.Backup)
            {
                if (CurrentScene.name == "Intro")
                {
                    if (CurrentWaypoint == WaypointList[2])
                    {
                        CurrentPlayer.transform.position = WaypointList[1].transform.position;
                        CurrentWaypoint = WaypointList[1];

                    }
                }

            }
        }
    }

    public void MovePlayerUturn()
    {
        CurrentPlayer.transform.Rotate(0,180,0);
    }
    
    public void RotateLeft()
    {
        CurrentPlayer.transform.Rotate(0,-90,0);
    }

    public void RotateRight()
    {
        CurrentPlayer.transform.Rotate(0,90,0);
    }

        public void FindCharacter()
        {
            if (ManagerScript != null && ManagerScript.CurrentPlayer != null)
            {
                if (ManagerScript.CurrentPlayer.PlayerCharacter == Character.Alex)
                {
                    CurrentPlayer = GameObject.FindGameObjectWithTag("PlayerAlex");
                }
                else if (ManagerScript.CurrentPlayer.PlayerCharacter == Character.Anne)
                {
                    CurrentPlayer = GameObject.FindGameObjectWithTag("PlayerAnne");
                }
            }
        }
}
}