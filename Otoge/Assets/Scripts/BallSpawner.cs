using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

    Vector3 initialScale;
    public GameObject ballPrefab;
    public int ballIndex;
    public Timing[] spawnTimings;

	// Use this for initialization
	void Start () {
        Debug.Log("spawnTimingSize" + spawnTimings.Length);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Music.CurrentSection.name.StartsWith("Play")) {
            SpawnBall();
        }
	}

    void SpawnBall() {

        if (ballIndex < spawnTimings.Length && Music.isNowChanged) {
            //  if time for this ball is already passed away, turn for the next ball
            if (Music.Now.totalUnit > spawnTimings[ballIndex].totalUnit) {
                ballIndex++;
            }
        }


        if (ballIndex < spawnTimings.Length && Music.isNowChanged && 
            (spawnTimings[ballIndex].totalUnit - 4 == Music.Now.totalUnit)) {

            Debug.Log("ballIndex" + ballIndex + "\n" 
                      //                      + " spawningTime.Length " + spawnTimings.Length + "\n" 
                      + " Music.Now.totalUnit " + Music.Now.totalUnit + "\n" 
                      + " bar " + Music.Now.bar + "\n"
                      + " beat " + Music.Now.beat + "\n"
                      + " unit " + Music.Now.unit + "\n"
                      + " spawnTimings[ballIndex].totalUnit " + spawnTimings[ballIndex].totalUnit);

            Ball ball = (Instantiate (ballPrefab) as GameObject).GetComponent<Ball>();
            ball.transform.parent = transform;
            ball.transform.position = new Vector3(GameManager.instance.goalPos.x - 4.5f * (float)Music.MusicTimeUnit * ball.velocity.x, 
                                                  GameManager.instance.goalPos.y, 
                                                  GameManager.instance.goalPos.z);

            Debug.Log("MusicTimeUnit " + Music.MusicTimeUnit + "!!!!!!!!!!!");
//            Debug.Log("SpawnedBall pos: " + ball.transform.position.ToString());
            ball.Initialize(spawnTimings[ballIndex]);
            ballIndex++;
        }
    }

    public void OnRestart() {
        ballIndex = 0;
    }   

}
