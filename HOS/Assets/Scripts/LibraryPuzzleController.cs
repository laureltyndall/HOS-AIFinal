using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HOS;

public class LibraryPuzzleController : MonoBehaviour {

    public List<GameObject> FolderOrder;
    public GameObject FolderParent;
    public GameObject ClickedFolder1;
    public GameObject ClickedFolder2;
    public Vector3 SwitchingPosition;
    public List<Transform> CorrectPositions;
    public int CorrectFolders = 0;
    public float PuzzleTime = 0.0f;
    public int RunicClicks = 0;
    public int TotalClicks = 0;
    public Text TextArea;
    public GameObject SkipButton;
    private bool TextAreaFilled = false;
    public bool GameOver = false;

    public string PlayerName;
    public string SiblingName;
    public GameManager ManagerScript;
    private bool ManagerFound = false;
    private bool NamesFound = false;

    public AudioSource FolderNoise;

    private Vector3 CorrectEnglish1 = new Vector3(0f, 0f, 0f);
    private Vector3 CorrectEnglish2 = new Vector3(0f, 0f, 4f);
    private Vector3 CorrectEnglish3 = new Vector3(0f, 0f, 8f);
    private Vector3 CorrectEnglish4 = new Vector3(0f, 0f, 12f);
    private Vector3 CorrectGreek1 = new Vector3(0f, 0f, 16f);
    private Vector3 CorrectGreek2 = new Vector3(0f, 0f, 20f);
    private Vector3 CorrectGreek3 = new Vector3(0f, 0f, 24f);
    private Vector3 CorrectGreek4 = new Vector3(0f, 0f, 28f);
    private Vector3 CorrectGreek5 = new Vector3(0f, 0f, 32f);
    private Vector3 CorrectRunic1 = new Vector3(0f, 0f, 36f);
    private Vector3 CorrectRunic2 = new Vector3(0f, 0f, 40f);
    private Vector3 CorrectRunic3 = new Vector3(0f, 0f, 44f);
    private Vector3 CorrectRunic4 = new Vector3(0f, 0f, 48f);
    private Vector3 CorrectRunic5 = new Vector3(0f, 0f, 52f);
    private Vector3 CorrectRussian1 = new Vector3(0f, 0f, 56f);
    private Vector3 CorrectRussian2 = new Vector3(0f, 0f, 60f);
    private Vector3 CorrectRussian3 = new Vector3(0f, 0f, 64f);
    private Vector3 CorrectRussian4 = new Vector3(0f, 0f, 68f);
    
    // Use this for initialization
    void Start () {
		foreach (Transform child in FolderParent.transform)
        {
            FolderOrder.Add(child.gameObject);
        }

        FindManagerScript();
        FindNames();

        if(NamesFound)
        {
            TextArea.text = "If I don't put these back in order, " + SiblingName + " is going to skin me alive!";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(!ManagerFound)
        {
            FindManagerScript();
            FindNames();

            if (NamesFound)
            {
                TextArea.text = "If I don't put these back in order, " + SiblingName + " is going to skin me alive!";
            }
        }

        if (!GameOver)
        {
            if (!TextAreaFilled)
            {
                TextArea.text = "If I don't put these back in order, " + SiblingName + " is going to skin me alive!";
                TextAreaFilled = true;
            }

            PuzzleTime += Time.deltaTime;

            if (PuzzleTime >= 50f)
            {
                SkipButton.SetActive(true);
            }

            foreach (GameObject go in FolderOrder)
            {
                if (go.GetComponentInChildren<FolderIndicator>().Clicked)
                {
                    if (ClickedFolder1 == null)
                    {
                        ClickedFolder1 = go;
                        go.GetComponentInChildren<FolderIndicator>().Clicked = false;
                    }
                    else if (ClickedFolder2 == null)
                    {
                        ClickedFolder2 = go;
                        go.GetComponentInChildren<FolderIndicator>().Clicked = false;
                    }

                    TotalClicks++;
                }
            }

            if (ClickedFolder1 != null)
            {
                if (ClickedFolder2 != null)
                {
                    SwitchingPosition = ClickedFolder1.transform.position;
                    ClickedFolder1.transform.position = ClickedFolder2.transform.position;
                    ClickedFolder2.transform.position = SwitchingPosition;

                    ClickedFolder1 = null;
                    ClickedFolder2 = null;
                    SwitchingPosition = new Vector3();

                    FolderNoise.Play();
                }
            }

            if (TotalClicks == 5)
            {
                TextArea.text = "Let's see, the first thing I should probably do is color-code the folders. " + SiblingName + " is pretty OCD about things, so the colors should probably be in order alphabetically.";
            }
            if (TotalClicks == 10)
            {
                TextArea.text = "I looks like the black folders are the English alphabet, the green are runes (geek), blue is the Greek alphabet, and red looks like - Russian?";
            }

            if (CorrectFolders >= 17)
            {
                Debug.Log("Game Won!");
                TextArea.text = "Got it!";
                GameOver = true;
            }
            else
            {
                CheckForCorrectSequence();
            }
        }
        else if (GameOver)
        {
            TextArea.text = "Got it!";
            if(ManagerFound)
            {
                ManagerScript.CurrentPlayer.gameObject.SetActive(false);
                ManagerScript.GroundsFromGate = false;
                ManagerScript.GroundsFromHouse = false;
                ManagerScript.HouseFromGrounds = false;
                ManagerScript.HousefromInside = false;
                ManagerScript.KitchenFromHall = false;
                ManagerScript.KitchenFromGame = false;
                ManagerScript.LRFromHall = false;
                ManagerScript.LRFromGame = true;
                ManagerScript.LRFromUnderground = false;
                ManagerScript.CenterFromMaze = false;
                ManagerScript.CenterFromGame = false;
                ManagerScript.HallfromOutside = false;
                ManagerScript.HallFromRoom = false;
                ManagerScript.LoadScene("Living Room");
            }
        //    Time.timeScale = 0;
        }
    }

    void CheckForCorrectSequence()
    {
        CorrectFolders = 0;

        foreach (Transform go in CorrectPositions)
        {
            if (go.name == "English1")
            {
                if (go.transform.position == CorrectEnglish1)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "English2")
            {
                if (go.transform.position == CorrectEnglish2)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "English3")
            {
                if (go.transform.position == CorrectEnglish3)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "English4")
            {
                if (go.transform.position == CorrectEnglish4)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Greek1")
            {
                if (go.transform.position == CorrectGreek1)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Greek2")
            {
                if (go.transform.position == CorrectGreek2)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Greek3")
            {
                if (go.transform.position == CorrectGreek3)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Greek4")
            {
                if (go.transform.position == CorrectGreek4)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Greek5")
            {
                if (go.transform.position == CorrectGreek5)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Runes1")
            {
                if (go.transform.position == CorrectRunic1)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Runes2")
            {
                if (go.transform.position == CorrectRunic2)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Runes3")
            {
                if (go.transform.position == CorrectRunic3)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Runes4")
            {
                if (go.transform.position == CorrectRunic4)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Runes5")
            {
                if (go.transform.position == CorrectRunic5)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Russian1")
            {
                if (go.transform.position == CorrectRussian1)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Russian2")
            {
                if (go.transform.position == CorrectRussian2)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Russian3")
            {
                if (go.transform.position == CorrectRussian3)
                {
                    CorrectFolders++;
                }
            }
            else if (go.name == "Russian4")
            {
                if (go.transform.position == CorrectRussian4)
                {
                    CorrectFolders++;
                }
            }
        }
    }

    public void SkipGame()
    {
        foreach (GameObject go in FolderOrder)
        {
            if (go.name == "English1")
            {
                go.transform.position = CorrectEnglish1;
            }
            else if (go.name == "English2")
            {
                go.transform.position = CorrectEnglish2;
            }
            else if (go.name == "English3")
            {
                go.transform.position = CorrectEnglish3;
            }
            else if (go.name == "English4")
            {
                go.transform.position = CorrectEnglish4;
            }
            else if (go.name == "Greek1")
            {
                go.transform.position = CorrectGreek1;
            }
            else if (go.name == "Greek2")
            {
                go.transform.position = CorrectGreek2;
            }
            else if (go.name == "Greek3")
            {
                go.transform.position = CorrectGreek3;
            }
            else if (go.name == "Greek4")
            {
                go.transform.position = CorrectGreek4;
            }
            else if (go.name == "Greek5")
            {
                go.transform.position = CorrectGreek5;
            }
            else if (go.name == "Runes1")
            {
                go.transform.position = CorrectRunic1;
            }
            else if (go.name == "Runes2")
            {
                go.transform.position = CorrectRunic2;
            }
            else if (go.name == "Runes3")
            {
                go.transform.position = CorrectRunic3;
            }
            else if (go.name == "Runes4")
            {
                go.transform.position = CorrectRunic4;
            }
            else if (go.name == "Runes5")
            {
                go.transform.position = CorrectRunic5;
            }
            else if (go.name == "Russian1")
            {
                go.transform.position = CorrectRussian1;
            }
            else if (go.name == "Russian2")
            {
                go.transform.position = CorrectRussian2;
            }
            else if (go.name == "Russian3")
            {
                go.transform.position = CorrectRussian3;
            }
            else if (go.name == "Russian4")
            {
                go.transform.position = CorrectRussian4;
            }
        }
    }

    void FindNames()
    {
        if (PlayerName != "")
        {
            if (PlayerName == "Alex")
            {
                SiblingName = "Anne";
                NamesFound = true;
            }
            else if (PlayerName == "Anne")
            {
                SiblingName = "Alex";
                NamesFound = true;
            }
        }
        else
        {
            SiblingName = "Alex";
            NamesFound = true;
        }
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
                    PlayerName = ManagerScript.CurrentPlayer.PlayerName;

                    if (PlayerName != "")
                    {
                        FindNames();
                    }

                    ManagerFound = true;
                }
            }
        }
    }
}
