using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
//    public BallSpawner ballSpawner;
    public Vector3 goalPos;
    public GUIText clearText;
    public GUIText retryText;
    ScoreManager scoreManager;
//    public bool gameOver;
//    public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
        instance = this;
        clearText.enabled = false;
        retryText.enabled = false;
        goalPos = GameObject.FindGameObjectWithTag("Goal").gameObject.transform.position;
        if (goalPos == null) {
            Debug.LogError("GameManager: goalPos is null");
        }

        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (scoreManager == null) {
            Debug.LogError("GameManager: scoreManager is null");
        }

        CalculatePlayerLevel(); 
//        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (Music.CurrentSection.name) {
        case "Start" :
            if (Music.IsJustChangedSection("Start")) {
                Debug.Log("Music Entered Start");
            }
            UpdateStart();
            break;
        case "Clear" :
            if (Music.IsJustChangedSection("Clear")) {
                Debug.Log("Music entered Clear");
            }
            UpdateClear();
            break;
        case "GameOver" :
            if (Music.IsJustChangedSection("GameOver")) {
                Debug.Log("Music entered GameOver");
            }
            UpdateGameOver();
            break;
        default: // Play
            if (Music.IsJustChangedSection("Play")) {
                Debug.Log("Music entered Play");
            }
//            if (Music.IsJustChangedSection("Play2")) {
//                Debug.Log("Music entered Play2");
//            }
//            if (Music.IsJustChangedSection("Play3")) {
//                Debug.Log("Music entered Play3");
//            }
            break;
	    }
	}

    void UpdateStart() {
        if (Input.GetMouseButtonDown(0)) {
            Music.SeekToSection("Play");
        }
    }

    void UpdateClear() {
        if (Music.IsJustChangedSection()) {
            clearText.enabled = true;
        }

        if (Music.IsJustChangedAt(Music.CurrentSection.StartTiming_.bar + 3)) {
            Music.Stop();
        }

        if (Input.GetMouseButtonDown(0)) {
            Restart();
        }
    }

    void UpdateGameOver() {
//        GUI.skin = guiSkin;
        if (Music.IsJustChangedSection()) {
            retryText.enabled = true;
            retryText.text = "See Game Result";
        }
        
        if (Music.IsJustChangedAt(Music.CurrentSection.StartTiming_.bar + 3)) {
            Music.Stop();
        }
        
        if (Input.GetMouseButtonDown(0)) {
            SavePlayerData();
            LoadScoreLevel();
        }
    }

    void CalculatePlayerLevel() {
        int level = 1;
        if (Application.loadedLevelName == "Level1") {
            level = 1;
        } else if (Application.loadedLevelName == "Level2") {
            level = 2;
        } else if (Application.loadedLevelName == "Level3") {
            level = 3;
        }

        if (level > scoreManager.level) {
            scoreManager.level = level;
        }
    }


    public void SavePlayerData() {
        PlayerPrefs.SetInt("Score" , scoreManager.score);
        if (scoreManager.score > PlayerPrefs.GetInt("Score")) {
            PlayerPrefs.SetInt("BestScore", scoreManager.score);
        }
        PlayerPrefs.SetInt("Excellent", scoreManager.excellentTime);
        PlayerPrefs.SetInt("Good", scoreManager.goodTime);
        PlayerPrefs.SetInt("Miss", scoreManager.missTime);
        PlayerPrefs.SetInt("Level", scoreManager.level);

    }

    public void LoadScoreLevel() {
        Application.LoadLevel("Score");
    }

    void Restart() {
        Music.SeekToSection("Start");
        Music.Play("Music");    // Name of the GameObject
//        ballSpawner.OnRestart();
        retryText.enabled = false;
        clearText.enabled = false;
    }
}
