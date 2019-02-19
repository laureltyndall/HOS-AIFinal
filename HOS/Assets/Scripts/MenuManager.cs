using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public float TimeStamp = 10.0f;
    public int scene_number;
    public GameObject PauseMenu;
    public float CurrentGameTime;

    // Use this for initialization
    void Start ()
    {
        // For the pause menu - set up the game to read time
        Time.timeScale = 1;
        TimeStamp = Time.time + 10.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CurrentGameTime = Time.time;

        // Find the P Key - This will be used to pause the game and bring up the pause menu UI panel
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPauseMenu();
        }

        if (scene_number == 1)
        {
            if (Time.time >= TimeStamp)
            {
                TimeStamp += 10.0f;
            }
        }
    }

    // This is a simple script to reload the game if the player chooses to click the reload button on the pause menu.
    // This script will load the given index number of the scene it is passed from the button click in the Unity engine.
    public void LoadOnClick(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // This is a simple script to be called when a player has decided  to click the quit button on the pause menu.
    // All this script will do is quit the game.
    public void QuitOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void TogglePanel(GameObject panel)
    {
        // If the pause menu is on, turn it off. If it is off, turn it on
        panel.SetActive(!panel.activeSelf);
    }

    public void ShowPauseMenu()
    {
        // If the pause menu is on, turn it off. If it is off, turn it on
        PauseMenu.SetActive(!PauseMenu.activeSelf);

        if (!PauseMenu.activeSelf)   // If the scene is paused
        {
            // Unpause the scene
            Time.timeScale = 1;

        }
        else                         // If the scene is not paused
        {
            // Pause the scene
            Time.timeScale = 0;
        }
    }

    public void OnMouseEnter(Texture2D NewCursor)
    {
        // Use this to set the cursor to the chosen sprite image
        Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        // This sets the cursor back to default
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
