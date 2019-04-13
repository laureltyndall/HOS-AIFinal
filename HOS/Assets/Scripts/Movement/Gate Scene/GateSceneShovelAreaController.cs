using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class GateSceneShovelAreaController : MonoBehaviour
    {
        public bool Clickable = true;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public GameManager ManagerScript;
        public Text TextArea;
        public bool ManagerFound = false;
        public MeshRenderer Shovel;
        public CapsuleCollider MyCollider;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ManagerFound)
            {
                GameObject gm = GameObject.FindGameObjectWithTag("GameController");
                ManagerScript = gm.gameObject.GetComponent<GameManager>();

                if (ManagerScript != null)
                {
                    ManagerFound = true;
                }
            }
            else
            {
                if (ManagerScript.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Trowel))
                {
                    Clickable = false;
                }
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                //If your mouse hovers over the GameObject with the script attached, output this message
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
                }
            }
        }

        void OnMouseExit()
        {
            if (Clickable)
            {
                //The mouse is no longer hovering over the GameObject so output this message each frame
                //      Debug.Log("Mouse is no longer on " + this.name);
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }

        private void OnMouseDown()
        {
            if (Clickable)
            {
                Debug.Log(this.name + " has been clicked");
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[4].transform.position;
                    MovementScript.CurrentWaypoint = MovementScript.WaypointList[4];
                    //     MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                    Camera.main.transform.Rotate(new Vector3(50.28f, 7.2f, 0f));

                    MovementScript.CanUturn = false;
                    MovementScript.CanOrbit = false;
                    MovementScript.CanLeftTurn = false;
                    MovementScript.CanRightTurn = false;
                    MovementScript.CanForward = false;
                    MovementScript.CanBackup = true;

                    MyCollider.enabled = false;
                }
            }
        }
    }
}
