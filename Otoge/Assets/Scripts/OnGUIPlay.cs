using UnityEngine;
using System.Collections;

public class OnGUIPlay : MonoBehaviour {
    public Texture messageTexture_Excellent;
    public Texture messageTexture_Good;
    public Texture messageTexture_Miss;    
    public Texture hitEffectIcon;
    public GUISkin  guiSkin;
    private float buttonWidth = 150;
    private float buttonHeight = 40;
    Texture         messageTexture;
    ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
//        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (scoreManager == null) {
            Debug.LogError("scoreManager is null");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        if( GUI.Button( new Rect( (Screen.width - buttonWidth - 10), buttonHeight / 2.0f, buttonWidth, buttonHeight ), "Return to Menu" ) ){
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
