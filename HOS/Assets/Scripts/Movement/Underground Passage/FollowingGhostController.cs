using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class FollowingGhostController : MonoBehaviour
    {
        public PlayerCameraController MovementScript;
        public PassageManager UPManager;
        public Animator MyAnimation;
        public bool IsAttacking = false;
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

            if (UPManager.GhostOn && UPManager.GhostChasing && !UPManager.DontFollow)
            {
                IsAttacking = true;
                // Run towards location
                float StepSpeed = Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, UPManager.GhostMoveTo.transform.position, StepSpeed);
            }
            else
            {
                IsAttacking = false;
            }
        }
    }
}