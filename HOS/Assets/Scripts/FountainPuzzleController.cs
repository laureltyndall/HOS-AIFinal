using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FountainPuzzleController : MonoBehaviour {

    public List<GameObject> StarLocations;
    public List<GameObject> ClickableStars;
    public GameObject MoonstoneStarEmpty;
    public GameObject MoonstoneStarFilled;
    public Text TextAreaSmall;
    public GameObject RiddleAnswerPanel;
    public GameObject StarRiddleSphere;
    public GameObject RainbowRiddleSphere;
    public GameObject CloseUpCamera;
    private float StarTurnTimer = 4f;
    private bool BeginStars = false;
    public bool MoonstoneInsterted = false;
    private bool RiddleSolved = false;

    private int WrongClicksCount = 0;

    // Use this for initialization
    void Start () {
        TextAreaSmall.text = "It looks like I should put the star I found in that empty space.";
        StarRiddleSphere.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        if (!MoonstoneInsterted)
        {
            CloseUpCamera.SetActive(false);
        }
        else
        {
            if (RiddleSolved)
            {
                if (BeginStars)
                {
                    if (StarTurnTimer > 0f)
                    {
                        TextAreaSmall.text = "It looks like the stars are turning around.";

                        StarTurnTimer -= Time.deltaTime;

                        foreach (GameObject go in StarLocations)
                        {
                            go.gameObject.GetComponent<RotateStars>().StarsTurning = true;
                        }
                    }
                    else
                    {
                        //foreach (GameObject go in StarLocations)
                        //{
                        //    go.SetActive(false);
                        //}
                        foreach (GameObject go in ClickableStars)
                        {
                            go.transform.position = new Vector3(go.transform.position.x, 0.047f, go.transform.position.z);
                        }

                        BeginStars = false;
                    }
                }
            }
            else
            {
                CloseUpCamera.SetActive(true);
                RiddleAnswerPanel.SetActive(true);
                StarRiddleSphere.SetActive(false);
                TextAreaSmall.text = "'You see me in the air, but I am not a kite. I am what's created when water refracts light.' - Hm.";
            }
        }
    }

    public void WrongAnswerClicked()
    {
        WrongClicksCount++;
        TextAreaSmall.text = "Hm. Nothing happened. I don't think that's right.";
    }

    public void RightAnswerClicked()
    {
        CloseUpCamera.SetActive(false);

        if(WrongClicksCount >= 2)
        {
            TextAreaSmall.text = "Right. Rainbow. Of course.";
        }
        else
        {
            TextAreaSmall.text = "Got it!";
        }

        BeginStars = true;
        RiddleSolved = true;
    }
}
