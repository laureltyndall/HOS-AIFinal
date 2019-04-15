using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class DialogueController : MonoBehaviour
    {
        private PlayerCameraController MovementScript;
        public List<string> TwinConvo;
        private bool NamesFound = false;
        private bool ListPopulated = false;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        private void Update()
        {
            if(!NamesFound)
            {
                if(MovementScript.PlayerName == "Alex" || MovementScript.PlayerName == "Anne")
                {
                    NamesFound = true;
                }
                else
                {
                    NamesFound = false;
                }
            }
            else
            {
                if(!ListPopulated)
                {
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''" + MovementScript.PlayerName + "? Is that you?''");   //0
                    TwinConvo.Add(MovementScript.SiblingName + "! Thank goodness I found you!");               //1
                    TwinConvo.Add("What are you doing down here?");               //2
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''You wouldn't believe me if I told you.''");   //3
                    TwinConvo.Add("Was it that thing I've been seeing around your house?");               //4
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''You saw it, too?''");   //5
                    TwinConvo.Add("What IS it?"); //6
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''I don't know! The realtor said that the old owners left without giving her an explanation, but I thought it might have been because of the mouse problem.''");   //7
                    TwinConvo.Add("Yeah. I've gotten up close and personal with your mouse problem."); //8
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''They're horrible, right?''");   //9
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''How did you figure out I was down here?''");   //10
                    TwinConvo.Add("Tediously."); //11
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''I'm sorry. Not really a great housewarming, huh?''");   //12
                    TwinConvo.Add("We'll think about housewarming once we get out of this place. For the record? Underground passage? Very cool."); //13
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''Yeah, it's not so great once you've been stuck down here for a while. Creepy is an understatement.''");   //14
                    TwinConvo.Add("Can't you get out? How'd you get stuck in there?"); //15
                    TwinConvo.Add(MovementScript.SiblingName + ": \n  ''That thing was chasing me! I managed to get in here, but now the door is stuck!''");   //16
                    TwinConvo.Add("Maybe if I push and you pull, we might be able to get it to move."); //17
                    TwinConvo.Add(MovementScript.SiblingName + ": \n ''I'll try anything!''");   //18
                    TwinConvo.Add("Okay. On three then."); //19
                    TwinConvo.Add("One."); //20
                    TwinConvo.Add("Two."); //21
                    TwinConvo.Add("Three!"); //22
                    TwinConvo.Add("Got it!"); //23

                    ListPopulated = true;
                }
            }
        }
    }
}