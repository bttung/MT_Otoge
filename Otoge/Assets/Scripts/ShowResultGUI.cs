using UnityEngine;
using System.Collections;

public class ShowResultGUI : MonoBehaviour {

    public string title = "";
    public string scoreLabel = "";
    private string detailScore = "";
    public GUISkin guiStyle;
    int score;
    int excellent;
    int good;
    int miss;
    private float buttonWidth;
    private float buttonHeight;

	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        excellent = PlayerPrefs.GetInt("Excellent");
        good = PlayerPrefs.GetInt("Good");
        miss = PlayerPrefs.GetInt("Miss");
        detailScore = "Excellent: " + excellent.ToString() + "\n"
                        + "Good: " + good.ToString() + "\n"
                        + "Miss: " + miss.ToString();
        buttonWidth = 150;
        buttonHeight = 40;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.skin = guiStyle;
        GUI.Box(new Rect(10.0f, 30.0f, Screen.width - 20.0f, Screen.height - 20.0f), title);
        GUI.Label( new Rect( 20, 50, 200, 40), scoreLabel + score.ToString() );
                       
        GUILayout.BeginArea(new Rect(30.0f, 70.0f, Screen.width - 20.0f, Screen.height - 40.0f));
        GUILayout.Label(detailScore);
        GUILayout.EndArea();

        if( GUI.Button( new Rect( Screen.width / 2.0f, 100, buttonWidth, buttonHeight ), "Return to Menu" ) ){
            Application.LoadLevel("Menu");
        }
    }
}
