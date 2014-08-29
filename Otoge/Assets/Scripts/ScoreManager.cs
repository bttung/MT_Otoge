using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

    public int MISS = 0;
    public int GOOD = 5;
    public int EXCELLENT = 10;
    private float GOOD_ERROR = 15.0f;
    private float EXCELLENT_ERROR = 10.0f;
    private float ANIM_TIME = 0.5f;
    private float animatedTime;

    private DanceController danceCtr;
    private string goodPoseName;
    private BallSpawner ballSpanwer;
    public int level;
    public int score;
    public int excellentTime;
    public int goodTime;
    public int missTime;
    private int additionalScore;
    private int checkedIndex;
    public GUIText summary;

	// Use this for initialization
	void Start () {
        // danceCtr = GameObject.FindGameObjectWithTag("Player").GetComponent<DanceController>();
        danceCtr = GameObject.Find("UnityChan").GetComponent<DanceController>();
        if (danceCtr == null) {
            Debug.LogError("ScoreManager: danceCtr null");
        }

        ballSpanwer = GameObject.FindGameObjectWithTag("BallSpawner").GetComponent<BallSpawner>();
        if (ballSpanwer == null) {
            Debug.LogError("ScoreManager: ballSpawner is null");
        }

        score = 0;
        additionalScore = 0;
        summary.text = "";
        checkedIndex = 0;
        animatedTime = 0;
        excellentTime = 0;
        goodTime = 0;
        missTime = 0;

        // Receive new action depend on playerLevel
        level = PlayerPrefs.GetInt("Level");
        if (level <= 0) {
            level = 1;
        }
        List<string> goodPose = Pose.GetPoseList(level);
        goodPoseName = goodPose[goodPose.Count - 1];

	}
	
    void ConfigureGoodPose() {

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
	}

    void CheckScore() {
        float error = Music.MusicalTimeFrom(ballSpanwer.spawnTimings[ballSpanwer.ballIndex]);
        error = Mathf.Abs(error);
        // Debug.Log("error: " + error + " Score: " + score);  
        
        if (error < EXCELLENT_ERROR) {
            checkedIndex = ballSpanwer.ballIndex;
            additionalScore = EXCELLENT;
            score += EXCELLENT;
            excellentTime++;
            return;
        }
        
        if (error <= GOOD_ERROR) {
            checkedIndex = ballSpanwer.ballIndex;
            additionalScore = GOOD;
            score += GOOD;
            goodTime++;
            return;
        }

        if (error > GOOD_ERROR) {
            // If user missed the ball, he can click again and take the score if he hit good or excellent
            additionalScore = MISS;
            missTime++;
            return;
        }
    }



    void DoAnimation() {
        if (additionalScore == GOOD) {
            danceCtr.DoAnimation(goodPoseName);
        } else if (additionalScore == EXCELLENT) {
            danceCtr.DoAnimation(Pose.DANCE_EXCELLENT);
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
