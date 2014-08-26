using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (Music.CurrentSection.name) {
        case "Start" :
            if (Music.IsJustChangedSection("Start")) {
                Debug.Log("Music Entered Start");
            }
            break;
        case "Clear" :
            if (Music.IsJustChangedSection("Clear")) {
                Debug.Log("Music entered Clear");
            }
            break;
        case "GameOver" :
            if (Music.IsJustChangedSection("GameOver")) {
                Debug.Log("Music entered GameOver");
            }
            break;
        default: // Play
            if (Music.IsJustChangedSection("Play")) {
                Debug.Log("Music entered Play");
            }
            if (Music.IsJustChangedSection("Play2")) {
                Debug.Log("Music entered Play2");
            }
            if (Music.IsJustChangedSection("Play3")) {
                Debug.Log("Music entered Play3");
            }
            break;
	    }
	}
}
