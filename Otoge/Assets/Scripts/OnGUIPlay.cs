using UnityEngine;
using System.Collections;

public class OnGUIPlay : MonoBehaviour {
    public Texture messageTexture_Excellent;
    public Texture messageTexture_Good;
    public Texture messageTexture_Miss;    
    public Texture hitEffectIcon;
    public GUISkin  guiSkin;
    private float buttonWidth = 500;
    private float buttonHeight = 80;
    Texture         messageTexture;
    ScoreManager scoreManager;
    GameManager gameManager;

	// Use this for initialization
	void Start () {
//        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (scoreManager == null) {
            Debug.LogError("scoreManager is null");
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.skin = guiSkin;
        GUI.Box(new Rect(50.0f, 100.0f, Screen.width - 20.0f, Screen.height - 20.0f), "Score: " + scoreManager.score);

        if( GUI.Button( new Rect( (Screen.width - buttonWidth - 10), buttonHeight / 2.0f, buttonWidth, buttonHeight ), 
                       "Return to Menu", 
                       CustomStyle.GetStyle())) {

            // Save Player data before load another scene
            gameManager.SavePlayerData();

            Application.LoadLevel("Menu");
        }
    }

    public void ExchangeHitTexture(int additionalScore) {
        if (additionalScore == scoreManager.MISS) {
            messageTexture = messageTexture_Miss;
        } else if (additionalScore == scoreManager.GOOD){
            messageTexture = messageTexture_Good;
        } else if (additionalScore == scoreManager.EXCELLENT) {
            messageTexture = messageTexture_Excellent;
        }
    }
}
