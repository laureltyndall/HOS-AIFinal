using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOS
{
    public class LetterNarration : MonoBehaviour
    {

        public List<string> Narration;
        public List<string> CharacterSpeaks;
        private GameManager Manager;
        public string CharacterName;
        public string SiblingName;

        // Use this for initialization
        void Start()
        {

            GameObject ag = GameObject.FindGameObjectWithTag("GameManager");
            Manager = ag.gameObject.GetComponent<GameManager>();

            if (Manager != null)
            {
                if (Manager.CurrentPlayer != null)
                {
                    CharacterName = Manager.CurrentPlayer.PlayerCharacter.ToString();
                    
                    if (CharacterName == "Anne")
                    {
                        SiblingName = "Alex";
                    }
                    else if (CharacterName == "Alex")
                    {
                        SiblingName = "Anne";
                    }
                }
                else
                {
                    CharacterName = "Anne";
                    SiblingName = "Alex";
                }
            }

            CharacterSpeaks.Add("I should go check on " + SiblingName + " and see what's going on.");
            CharacterSpeaks.Add("Is  that...  blood?");
            CharacterSpeaks.Add("A  new  house?");

            Narration.Add("Anyway,   I really hope that you'll come out and visit me soon - creepy new house and all. \n \n See you soon  (I hope). \n \n" + SiblingName);
            Narration.Add("It's night time, and although part of me is dying to know what frightened the old owners away, another part of me is starting to feel a little uneasy. \n \n I should be excited, but for some reason, i feel on edge, like something's out of whack. ");
            Narration.Add("The realtor gave me a great deal on it. In fact, it seemed like she couldn't wait to get rid of the thing. \n When I asked her why, all she would say is that it's been on and off the market for a while now - that no one seems to keep it very long, and that many of the old owners would just up and leave pretty abruptly. \n \n The place is huge and old - and a little creepy, under the circumstances.  You should hear this wind!");
            Narration.Add("Dear " + CharacterName + ", \n I know that I haven't written you in a while, and for that I'm sorry! \n After mom and dad died, I just had to get away from it all, you know ? But I'm back stateside now, and I think I'm finally ready to settle myself somewhere - namely stormy San Francisco! \n  I know you won't believe it, but I actually just bought a house out here on the very outskirts of town.");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}