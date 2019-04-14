using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class GhostControllerHall : MonoBehaviour
    {
        public PlayerCameraController MovementScript;
        public Text TextArea;
        public HallwayMananger HallManager;
        public Animator MyAnimation;
        public bool IsAttacking = false;
        public Transform EndPoint;
        private bool EndReached = false;
        private float Speed = 2f;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsAttacking)
            {
                MyAnimation.SetBool("Attacking", true);
            }
            else
            {
                MyAnimation.SetBool("Attacking", false);
            }

            if (HallManager.GhostOn && !HallManager.GhostInPosition)
            {
                IsAttacking = true;
                // Run towards location
                float StepSpeed = Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, StepSpeed);
            }
            else
            {
                IsAttacking = false;
            }

            if (transform.position == EndPoint.position)
            {
                HallManager.GhostInPosition = true;
            }
        }
    }
}