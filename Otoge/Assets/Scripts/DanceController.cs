using UnityEngine;
using System.Collections;

public class DanceController : MonoBehaviour {

    protected Animator avatar;
    public string animName;
    private float animTime;

	// Use this for initialization
	void Start () {
        avatar = gameObject.GetComponent<Animator>();
        animTime = 0.1f;
	}
	

    public void DoAnimation(string pose) {
        animName = pose;
//        Debug.Log("pose " + pose);
        avatar.SetBool(pose, true);
        StartCoroutine(StopAnimation(pose));
    }

    IEnumerator StopAnimation(string pose) {
        yield return new WaitForSeconds(animTime);
        avatar.SetBool(pose, false);
//        Debug.Log("Stopped Animation");
    }

}
