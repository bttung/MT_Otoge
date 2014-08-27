using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static int MISS = 0;
    private static int GOOD = 3;
    private static int EXCELLENT = 10;

    private BallSpawner ballSpanwer;
    private int score;

	// Use this for initialization
	void Start () {
        ballSpanwer = GameObject.FindGameObjectWithTag("BallSpawner").GetComponent<BallSpawner>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
