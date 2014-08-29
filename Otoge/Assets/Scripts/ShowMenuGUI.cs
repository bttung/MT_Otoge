using UnityEngine;
using System.Collections;

public class ShowMenuGUI : MonoBehaviour {

    public string title = "";
    public GUISkin guiStyle;
    private float buttonHeight;
    private float buttonWidth;

	// Use this for initialization
	void Start () {
        buttonWidth = 150;
        buttonHeight = 40;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.skin = guiStyle;
        GUI.Box(new Rect(10.0f, 30.0f, Screen.width - 20.0f, Screen.height - 20.0f), title);                       

        if( GUI.Button( new Rect( Screen.width / 2.0f, 100, buttonWidth, buttonHeight ), "Level1" ) ){
            Application.LoadLevel("Level1");
        }
        if( GUI.Button( new Rect( Screen.width / 2.0f, 150, buttonWidth, buttonHeight ), "Level2" ) ){
//            Application.LoadLevel("Level2");
        }
        if( GUI.Button( new Rect( Screen.width / 2.0f, 200, buttonWidth, buttonHeight ), "Level3" ) ){
//            Application.LoadLevel("Level3");
        }
        if( GUI.Button( new Rect( Screen.width / 2.0f, 250, buttonWidth, buttonHeight ), "Score" ) ){
            Application.LoadLevel("Score");
        }
        if( GUI.Button( new Rect( Screen.width / 2.0f, 300, buttonWidth, buttonHeight ), "SelectSong" ) ){
            Application.LoadLevel("SelectSong");
        }
    }
}
