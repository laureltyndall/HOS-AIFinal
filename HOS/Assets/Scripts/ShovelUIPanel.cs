using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelUIPanel : MonoBehaviour {

    public Texture2D NewCursor;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.isActiveAndEnabled)
        {
            Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
        }
	}
}
