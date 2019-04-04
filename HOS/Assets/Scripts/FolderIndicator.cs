using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HOS;

public class FolderIndicator : MonoBehaviour {

    public Alphabet FolderLanguage;
    public int Position = 0;
    public Texture2D NewCursor;
    public bool Clicked = false;
    public int ClickMe = 0;
    public Text TextArea;
    private LibraryPuzzleController PuzzleController;

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        PuzzleController = go.GetComponent<LibraryPuzzleController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(name == "Greek1")
        {
            if(ClickMe >= 5)
            {
                TextArea.text = "This one has the Greek letter for Alpha.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "This one is probably the first folder in the greek section.";
            }
        }
        if (name == "Greek2")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "Why does Greek have to have a 'Z' near the beginning of the alphabet? It's so confusing.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "In the Greek alphabet, I think Zeta comes after Epsilon.";
            }
        }
        if (name == "Greek3")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "Remember, this isn't an 'A', this is Lamda.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "At least, even in Greek, 'L' comes after 'K'.";
            }
        }
        if (name == "Greek4")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "This is Pi. - I could readlly go for some pie right now.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "'O', and then 'P' - same as the Enlgish alphabet, technically. Man, now I really want some pie.";
            }
        }
        if (name == "Greek5")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "The 'Y' letter is Upsilon.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "Omega is the very last letter in the greek alphabet. It looks like a person's head and shoulders, if I'm remembering it correctly.";
            }
        }
        if (name == "Runes1")
        {
            PuzzleController.RunicClicks++;

            if (ClickMe >= 5)
            {
                TextArea.text = "I thinks Runes start with the one that looks like a deflated 'F'.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "This one is the first of the Rune section.";
            }

            if(PuzzleController.RunicClicks == 0)
            {
                TextArea.text = "What it - is that a runic alphabet? Just how much of a geek are you?";
            }
        }
        if (name == "Runes2")
        {
            PuzzleController.RunicClicks++;

            if (ClickMe >= 5)
            {
                TextArea.text = "This one looks like a bird beak! Binder 'B', maybe?";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "This is Runes number two.";
            }

            if (PuzzleController.RunicClicks == 0)
            {
                TextArea.text = "What it - is that a runic alphabet? Just how much of a geek are you?";
            }
        }
        if (name == "Runes3")
        {
            PuzzleController.RunicClicks++;

            if (ClickMe >= 5)
            {
                TextArea.text = "This one looks like an 'M'. That's porbably a midling letter.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "These runes should be in the middle of the alphabet.";
            }

            if (PuzzleController.RunicClicks == 0)
            {
                TextArea.text = "What it - is that a runic alphabet? Just how much of a geek are you?";
            }
        }
        if (name == "Runes4")
        {
            PuzzleController.RunicClicks++;

            if (ClickMe >= 5)
            {
                TextArea.text = "This looks like a dying 'T'.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "This isn't the last part of the Runic alphabet, but it is close.";
            }

            if (PuzzleController.RunicClicks == 0)
            {
                TextArea.text = "What it - is that a runic alphabet? Just how much of a geek are you?";
            }
        }
        if (name == "Runes5")
        {
            PuzzleController.RunicClicks++;

            if (ClickMe >= 5)
            {
                TextArea.text = "The last letter looks kind of like a 'Y'.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "This one must be the last part of the Rune section.";
            }

            if (PuzzleController.RunicClicks == 0)
            {
                TextArea.text = "What it - is that a runic alphabet? Just how much of a geek are you?";
            }
        }
        if (name == "Russian1")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "Russian at least looks like it starts the same - whatever that second letter is.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "'A', 'B', 'C' - crazy symbol that must somehow be a letter.";
            }
        }
        if (name == "Russian2")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "A three, really? I mean, I know it's not said like a three, but it certainly looks like one. But it can't come before 'A'.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "This one has to be the second part of the Russian Alphabet.";
            }
        }
        if (name == "Russian3")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "That kind of looks like pi and  - not pi? - I still want some pie.";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "'P' still comes near the end section of the alphabet, even in Russian.";
            }
        }
        if (name == "Russian4")
        {
            if (ClickMe >= 5)
            {
                TextArea.text = "An upside down 'H', and a backwards 'R'. How does that make sense?";
            }
            else if (ClickMe >= 10)
            {
                TextArea.text = "Russian must end in that backwards R.";
            }
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //      Debug.Log("Mouse is no longer on " + this.name);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDown()
    {
        ClickMe++;
        Debug.Log(this.name + " has been clicked");
        Clicked = true;
    }
}
