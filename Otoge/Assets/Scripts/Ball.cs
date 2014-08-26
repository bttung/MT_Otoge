using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    Vector3 initialScale;

	// Use this for initialization
	void Start () {
        initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Music.CurrentSection.name.StartsWith("Play")) {
            UpdateScale();
        }
	}

    void UpdateScale() {
        transform.localScale = new Vector3(Random.Range(0.3f, 3.0f), Random.Range(0.3f, 3.0f), Random.Range(0.3f, 3.0f));
    }
}
