using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int MISS = 0;
    public int GOOD = 5;
    public int EXCELLENT = 10;
    public float GOOD_ERROR = 15.0f;
    public float EXCELLENT_ERROR = 5.0f;

    private BallSpawner ballSpanwer;
    private int score;
    private int checkedIndex;
    public GUIText summary;

	// Use this for initialization
	void Start () {
        ballSpanwer = GameObject.FindGameObjectWithTag("BallSpawner").GetComponent<BallSpawner>();
        score = 0;
        summary.text = "";
        checkedIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

        summary.text = "Score: " + score + " checkedIndex " + checkedIndex;

        if (!isInputed()) {
            return;
        }

        if (checkedIndex == ballSpanwer.ballIndex) {
            return;
        }

        float error = Music.MusicalTimeFrom(ballSpanwer.spawnTimings[ballSpanwer.ballIndex]);
        error = Mathf.Abs(error);
        Debug.Log("error: " + error);

	    if (error < EXCELLENT_ERROR) {
            score += EXCELLENT;
            checkedIndex = ballSpanwer.ballIndex;
            return;
        }

        if (error < GOOD_ERROR) {
            score += GOOD;checkedIndex = ballSpanwer.ballIndex;
            checkedIndex = ballSpanwer.ballIndex;
            return;
        }
	}

    bool isInputed() {
        if (Input.anyKey) {
            return true;
        }
        if (Input.touchCount > 0) {
            return true;
        }
        return false;
    }
}
