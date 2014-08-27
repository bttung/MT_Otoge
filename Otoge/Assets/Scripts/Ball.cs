using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    Vector3 initialScale;
    public Vector3 velocity;
    Timing spawnTiming;

	// Use this for initialization
	void Start () {
//        velocity = Vector3.zero;
	}
	
    public void Initialize(Timing timing) {
        this.spawnTiming = timing;
    }

    void Update() {
        float elapsedTime = Music.MusicalTimeFrom(spawnTiming);
        transform.position += velocity * Time.deltaTime;

        Debug.Log("Test vel: " + velocity.x * Time.deltaTime);

        if (Mathf.Abs(elapsedTime) <= 5.0f) {
            // Check Score

        } else if (Music.Just > spawnTiming ) {
            //Destroy(gameObject);
        }
    }

}
