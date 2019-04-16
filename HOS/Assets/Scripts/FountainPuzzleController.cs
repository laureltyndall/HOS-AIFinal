using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
using HOS;

public class FountainPuzzleController : MonoBehaviour
{

    public List<GameObject> StarLocations;
    public List<GameObject> ClickableStars;
    public GameObject MoonstoneStarEmpty;
    public GameObject MoonstoneStarFilled;
    public Text TextAreaSmall;
    public GameObject RiddleAnswerPanel;
    public GameObject StarRiddleSphere;
    public GameObject RainbowRiddleSphere;
    public GameObject CloseUpCamera;
    public float StarTurnTimer = 4f;
    private bool BeginStars = false;
    public bool MoonstoneInsterted = false;
    private bool RiddleSolved = false;
    public int ClickNumber = 0;
    public int TryCount = 0;
    public int NumberCorrect = 0;
    private bool GameOver = false;
    public GameManager ManagerScript;
    private bool ManagerFound = false;

    public GameObject RainbowHelper;

    private int WrongClicksCount = 0;

    public bool PlayerCameraFound = false;
    public GameObject PlayerCamera;

    public AudioSource Revolve;

    // Use this for initialization
    void Start()
    {
        TextAreaSmall.text = "It looks like I should put the star I found in that empty space.";
        StarRiddleSphere.SetActive(true);
        FindManagerScript();

    }

    // Update is called once per frame
    void Update()
    {
        if (!ManagerFound)
        {
            FindManagerScript();
        }
        else
        {
            if (!GameOver)
            {
                if (!MoonstoneInsterted)
                {
                    CloseUpCamera.SetActive(false);
                    if (MoonstoneStarEmpty.GetComponent<MoonstoneStarController>().Clicked)
                    {
                        MoonstoneInsterted = true;
                    }
                }
                else
                {
                    if (RiddleSolved)
                    {
                        if (BeginStars)
                        {
                            if (StarTurnTimer > 0f)
                            {
                                Revolve.Play();
                                TextAreaSmall.text = "It looks like the stars are turning around.";

                                StarTurnTimer -= Time.deltaTime;

                                foreach (GameObject go in StarLocations)
                                {
                                    go.gameObject.GetComponent<RotateStars>().StarsTurning = true;
                                }
                            }
                            else
                            {
                                foreach (GameObject go in ClickableStars)
                                {
                                    go.transform.position = new Vector3(go.transform.position.x, 0.047f, go.transform.position.z);
                                    go.gameObject.GetComponent<StarIndicator>().Clickable = true;
                                }

                                TextAreaSmall.text = "According to the riddle, I think these colors make up a rainbow. Maybe if I press them in the right oder, they might do something.";

                                BeginStars = false;
                            }
                        }
                        else
                        {
                            if (TryCount >= 5)
                            {
                                RainbowHelper.SetActive(true);
                            }

                            foreach (GameObject go in ClickableStars)
                            {
                                if (go.gameObject.GetComponent<StarIndicator>().Clicked)
                                {
                                    if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 0)
                                    {
                                        ClickNumber++;
                                        go.gameObject.GetComponent<StarIndicator>().ClickOrder = ClickNumber;
                                    }
                                }
                            }

                            if (ClickNumber == 7)
                            {
                                foreach (GameObject go in ClickableStars)
                                {
                                    if (go.gameObject.GetComponent<StarIndicator>().Clicked)
                                    {
                                        if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 1)
                                        {
                                            if (go.name == "Violet Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                        else if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 2)
                                        {
                                            if (go.name == "Indigo Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                        else if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 3)
                                        {
                                            if (go.name == "Blue Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                        else if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 4)
                                        {
                                            if (go.name == "Green Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                        else if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 5)
                                        {
                                            if (go.name == "Yellow Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                        else if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 6)
                                        {
                                            if (go.name == "Orange Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                        else if (go.gameObject.GetComponent<StarIndicator>().ClickOrder == 7)
                                        {
                                            if (go.name == "Red Star")
                                            {
                                                NumberCorrect++;
                                            }
                                        }
                                    }
                                }

                                if (NumberCorrect == 7)
                                {
                                    TextAreaSmall.text = "Got it!";
                                    GameOver = true;
                                }
                                else
                                {
                                    TextAreaSmall.text = "I don't think that was right. \n I need to click on the stars in the order of the colors in a rainbow.";
                                    foreach (GameObject go in ClickableStars)
                                    {
                                        go.gameObject.GetComponent<StarIndicator>().Clicked = false;
                                        go.gameObject.GetComponent<StarIndicator>().ClickOrder = 0;
                                        NumberCorrect = 0;
                                        ClickNumber = 0;
                                    }
                                    TryCount++;
                                }
                            }
                        }
                    }
                    else
                    {
                        CloseUpCamera.SetActive(true);
                        RiddleAnswerPanel.SetActive(true);
                        StarRiddleSphere.SetActive(false);
                        MoonstoneStarEmpty.SetActive(false);
                        TextAreaSmall.text = "'You see me in the air, but I am not a kite. I am what's created when water refracts light.' - Hm.";
                    }
                }
            }
            else
            {
                {
                    ManagerScript.FountainPuzzleFin = true;
                    //ManagerScript.CurrentPlayer.gameObject.SetActive(true);
                    ManagerScript.GroundsFromGate = false;
                    ManagerScript.GroundsFromHouse = false;
                    ManagerScript.HouseFromGrounds = false;
                    ManagerScript.HousefromInside = false;
                    ManagerScript.KitchenFromHall = false;
                    ManagerScript.KitchenFromGame = false;
                    ManagerScript.LRFromHall = false;
                    ManagerScript.LRFromGame = false;
                    ManagerScript.LRFromUnderground = false;
                    ManagerScript.CenterFromMaze = false;
                    ManagerScript.CenterFromGame = true;
                    ManagerScript.HallfromOutside = false;
                    ManagerScript.HallFromRoom = false;
                    ManagerScript.LoadScene("HedgeMazeCenter");
                }
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

        if (WrongClicksCount >= 2)
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

    void FindManagerScript()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");

        if (go != null)
        {
            ManagerScript = go.gameObject.GetComponent<GameManager>();

            if (ManagerScript != null)
            {
                if (ManagerScript.CurrentPlayer != null)
                {
                    ManagerScript.CurrentPlayer.gameObject.SetActive(false);

                    
                }
                ManagerFound = true;
            }
        }
    }
}
