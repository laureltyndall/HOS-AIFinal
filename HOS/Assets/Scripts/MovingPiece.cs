using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOS
{
    public class MovingPiece : MonoBehaviour
    {
        Rigidbody MyRigidbody;
        public bool IsMovingRight = false;
        public bool IsMovingLeft = false;
        public bool IsMovingUp = false;
        public bool IsMovingDown = false;

        private float Speed = 15.0f;

        public SliderGameController SliderGameScript;

        private float MovementSpeed = 200f;

        // Use this for initialization
        void Start()
        {
            SliderGameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<SliderGameController>();
            MyRigidbody = this.gameObject.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (IsMovingRight)
            {
                MyRigidbody.AddForce(Vector3.right * (Speed * Time.deltaTime), ForceMode.VelocityChange);
              //  transform.Translate(-Vector3.right * MovementSpeed * Time.deltaTime);
            }

            if (IsMovingLeft)
            {
                MyRigidbody.AddForce(Vector3.left * (Speed * Time.deltaTime), ForceMode.VelocityChange);
             //   transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
            }

            if (IsMovingUp)
            {
                MyRigidbody.AddForce(Vector3.up * (Speed * Time.deltaTime), ForceMode.VelocityChange);
             //   transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
            }

            if (IsMovingDown)
            {
                MyRigidbody.AddForce(Vector3.down * (Speed * Time.deltaTime), ForceMode.VelocityChange);
                // transform.Translate(-Vector3.right * MovementSpeed * Time.deltaTime);
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            collision.rigidbody.velocity = new Vector3(0, 0, 0);
            MyRigidbody.velocity = new Vector3(0, 0, 0);
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
                    SliderGameScript.RunWinGame();
                }
            }
        }


    }
}