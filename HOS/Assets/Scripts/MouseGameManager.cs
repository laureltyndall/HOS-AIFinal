using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HOS;
using System.Collections;

public class MouseGameManager : MonoBehaviour
{
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public Text m_MessageText;
    public GameObject[] MousePrefabs;
    public MouseManager[] m_Mice;
    public List<Transform> wayPointsForAI;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    private bool m_GameWinner;
 
    private void Start()
    {
        SpawnAllMice();
        //StartCoroutine(GameLoop());
        
    }

    public void SpawnAllMice()
    {

        m_Mice[0].m_Instance =
            Instantiate(MousePrefabs[0], m_Mice[0].m_SpawnPoint.position, m_Mice[0].m_SpawnPoint.rotation) as GameObject;
        m_Mice[0].m_PlayerNumber = 1;
        
        //setUp AI Mice
        for (int i = 1; i < m_Mice.Length; i++)
        {
            m_Mice[i].m_Instance = Instantiate(MousePrefabs[0], m_Mice[0].m_SpawnPoint.position, m_Mice[0].m_SpawnPoint.rotation) as GameObject;
            m_Mice[i].m_PlayerNumber = i + 1;
            m_Mice[i].SetupAI(wayPointsForAI);
        }
    }
    // This is called from start and will run each phase of the game one after another.
    private IEnumerator GameLoop()
    {
        // Start off by running the 'GameStarting' coroutine but don't return until it's finished.
        yield return StartCoroutine(GameStarting());

        // Once the 'GaneStarting' coroutine is finished, run the 'PlayingGame' coroutine but don't return until it's finished.
        yield return StartCoroutine(PlayingGame());

        // Once execution has returned here, run the 'GameEnding' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        // This code is not run until 'GameEnding' has finished.  At which point, check if a game winner has been found.
        if (!m_GameWinner)
        {
            // If there is a game winner, go to next scene.
            SceneManager.LoadScene(0);
        }
        else
        {
            // If there isn't a winner yet, restart this coroutine so the loop continues.
            // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            StartCoroutine(GameLoop());
        }
    }
    private IEnumerator GameStarting()
    {
        
        // Increment the round number and display text showing the players what round it is.
        m_MessageText.text = "Lure the mouse with cheese to a box. ";

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_StartWait;
    }

    private IEnumerator PlayingGame()
    {
        // Clear the text from the screen.
        m_MessageText.text = string.Empty;
        // ... return on the next frame.
        yield return null;
    }

    //Need help to determine when the player wins
    private IEnumerator GameEnding()
    {
        string message = EndMessage();
        m_MessageText.text = message;
        m_GameWinner = true;
        yield return null;
    }

    private string EndMessage()
    {
        string message = "You have run out of time the Mouse has eaten the map.";

        if (m_GameWinner)
        {
            message = "You now have the map of the maze.";
        }

        return message;
    }
}
