using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HOS
{
    public class WinSliderPuzzle : MonoBehaviour
    {

        public SliderGameController SliderGameScript;

        // Use this for initialization
        void Start()
        {
            SliderGameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<SliderGameController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            transform.Translate(new Vector3(0, 0, 0));

            if (other.tag == "Key")
            {
                // The Game is Won
                Debug.Log("Game is WON");
                SliderGameScript.RunWinGame();
            }
        }

    }
}