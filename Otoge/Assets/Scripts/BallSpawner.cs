using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

    Vector3 initialScale;
    public GameObject ballPrefab;
    public Timing[] spawnTimings;
    public int ballIndex;

	// Use this for initialization
	void Start () {
        initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Music.CurrentSection.name.StartsWith("Play")) {
            SpawnBall();
        }
	}

    void SpawnBall() {
        if (ballIndex < spawnTimings.Length && Music.isNowChanged && (spawnTimings[ballIndex].totalUnit - 4 == Music.Now.totalUnit)) {
            Ball ball = (Instantiate (ballPrefab) as GameObject).GetComponent<Ball>();
            ball.transform.parent = transform;
            ball.transform.position = new Vector3(GameManager.instance.goalPos.x - ball.velocity.x, 
                                                  GameManager.instance.goalPos.y, 
                                                  GameManager.instance.goalPos.z);

//            Debug.Log("SpawnedBall pos: " + ball.transform.position.ToString());
            ball.Initialize(spawnTimings[ballIndex]);
            ballIndex++;
        }
    }

    public void OnRestart() {
        ballIndex = 0;
    }   

}
