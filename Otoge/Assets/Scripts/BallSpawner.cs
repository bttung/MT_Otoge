using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

    Vector3 initialScale;
    public GameObject ballPrefab;
    public Timing[] spawnTimings;

    int ballIndex;

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
//        Debug.Log("TotalUnit " + spawnTimings[ballIndex].totalUnit + " Music.Now.totalUnit " + Music.Now.totalUnit);
        if (ballIndex < spawnTimings.Length && Music.isNowChanged && (spawnTimings[ballIndex].totalUnit - 4 == Music.Now.totalUnit)) {
            Ball ball = (Instantiate (ballPrefab) as GameObject).GetComponent<Ball>();
            ball.transform.parent = transform;
//            ball.transform.localPosition = Vector3.one;
//            ball.transform.localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));           
            ball.transform.position = new Vector3(GameManager.instance.goalPos.x - ball.velocity.x, GameManager.instance.goalPos.y, GameManager.instance.goalPos.z);
            Debug.Log("SpawnedBall pos: " + ball.transform.position.ToString());
            ball.Initialize(spawnTimings[ballIndex]);
//            Debug.Log("Spawn Ball @ " + Music.Now.totalUnit.ToString() + " ballIndex " + ballIndex.ToString() + " spawnTimingsLength " + spawnTimings.Length + "spawnTiming... totalUnit " + spawnTimings[ballIndex].totalUnit);
            ballIndex++;
        }
    }

    public void OnRestart() {
        ballIndex = 0;
    }

}
