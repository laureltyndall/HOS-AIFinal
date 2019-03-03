using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOS
{
    public class MovingPiece : MonoBehaviour
    {

        public bool IsMovingRight = false;
        public bool IsMovingLeft = false;
        public bool IsMovingUp = false;
        public bool IsMovingDown = false;

        public SliderGameController SliderGameScript;

        private float MovementSpeed = 200f;

        // Use this for initialization
        void Start()
        {
            SliderGameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<SliderGameController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsMovingRight)
            {
                transform.Translate(-Vector3.right * MovementSpeed * Time.deltaTime);
            }

            if (IsMovingLeft)
            {
                transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
            }

            if (IsMovingUp)
            {
                transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
            }

            if (IsMovingDown)
            {
                transform.Translate(-Vector3.right * MovementSpeed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            IsMovingRight = false;
            IsMovingLeft = false;
            IsMovingDown = false;
            IsMovingUp = false;
            transform.Translate(new Vector3(0, 0, 0));

            if (this.tag == "Key")
            {
                if (other.tag == "WinBorder")
                {
                    // The Game is Won
                    Debug.Log("Game is WON");
                }
            }
        }
    }
}