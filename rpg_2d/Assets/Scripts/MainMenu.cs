using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public Texture backgroundTexture;
    public GUIStyle random1;
    public float gamePlacementX1;
    public float gamePlacementX2;
    public float gamePlacementY1;
    public float gamePlacementY2;

    public bool showGUIOutline = true;
    public string level;

    private void OnGUI()
    {
        if (backgroundTexture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        }
        if(showGUIOutline){
            if (GUI.Button(new Rect(Screen.width * gamePlacementX1, 
                                    Screen.height * gamePlacementY1, 
                                    Screen.width * 0.5f, 
                                    Screen.height * 0.1f)
                           , "START GAME")){
                print("start game");
                Application.LoadLevel(level);
            }
            if (GUI.Button(new Rect(Screen.width * gamePlacementX2,
                                    Screen.height * gamePlacementY2,
                                    Screen.width * 0.5f,
                                    Screen.height * 0.1f)
                           , "SETTING"))
            {
                print("setting");
            }
        }else{
            if (GUI.Button(new Rect(Screen.width * gamePlacementX1,
                                    Screen.height * gamePlacementY1,
                                    Screen.width * 0.5f,
                                    Screen.height * 0.1f)
                           , "", random1))
            {
                print("start game");
            }
            if (GUI.Button(new Rect(Screen.width * gamePlacementX2,
                                    Screen.height * gamePlacementY2,
                                    Screen.width * 0.5f,
                                    Screen.height * 0.1f)
                           , "", random1))
            {
                print("setting");
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
