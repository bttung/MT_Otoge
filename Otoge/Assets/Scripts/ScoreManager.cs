using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int MISS = 0;
    public int GOOD = 5;
    public int EXCELLENT = 10;
    private float GOOD_ERROR = 20.0f;
    private float EXCELLENT_ERROR = 10.0f;
    private float ANIM_TIME = 0.5f;
    private float animatedTime;
    //private bool animated;

    private DanceController danceCtr;
    private BallSpawner ballSpanwer;
    private int score;
    private int additionalScore;
    private int checkedIndex;
    public GUIText summary;

	// Use this for initialization
	void Start () {
//        danceCtr = GameObject.FindGameObjectWithTag("Player").GetComponent<DanceController>();
        danceCtr = GameObject.Find("UnityChan").GetComponent<DanceController>();
        if (danceCtr == null) {
            Debug.Log("danceCtr null");
        }

        ballSpanwer = GameObject.FindGameObjectWithTag("BallSpawner").GetComponent<BallSpawner>();
        score = 0;
        additionalScore = 0;
        summary.text = "";
        checkedIndex = 0;
        animatedTime = 0;
//        animated = false;
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

        CheckScore();
        DoAnimation();

        score += additionalScore;
        additionalScore = 0;
	}

    void CheckScore() {
        float error = Music.MusicalTimeFrom(ballSpanwer.spawnTimings[ballSpanwer.ballIndex]);
        error = Mathf.Abs(error);
        Debug.Log("error: " + error + " Score: " + score);
        
        if (error < EXCELLENT_ERROR) {
//            score += EXCELLENT;
            additionalScore = EXCELLENT;
            checkedIndex = ballSpanwer.ballIndex;
            return;
        }
        
        if (error <= GOOD_ERROR) {
//            score += GOOD;
            additionalScore = GOOD;
            checkedIndex = ballSpanwer.ballIndex;
            checkedIndex = ballSpanwer.ballIndex;
            return;
        }

        if (error > GOOD_ERROR) {
            additionalScore = MISS;
            return;
        }
    }

    void DoAnimation() {
        if (additionalScore == GOOD) {
            danceCtr.DoAnimation(Pose.DANCE1);
        } else if (additionalScore == EXCELLENT) {
            danceCtr.DoAnimation(Pose.DANCE4);
        } else if (additionalScore == MISS) {
            danceCtr.DoAnimation(Pose.SLIPPED1);
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
