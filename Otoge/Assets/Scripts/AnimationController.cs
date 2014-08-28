using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    protected Animator avatar;

	// Use this for initialization
	void Start () {
        avatar = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (avatar) {
            int rand = Random.Range(0, 50);
           // avatar.SetBool("Jump_Small", rand == 20);
//            avatar.SetBool("Jump", rand == 20);
//            avatar.SetBool("Jump_High", rand == 20);
//            avatar.SetBool("Slide", rand == 20);      // Slide is bad action
//            avatar.SetBool("Lose", rand == 20);         // This one is also not work well
//            avatar.SetBool("Hand_Up", rand == 30);       // Also this one
//            avatar.SetBool("Hand_Up", true);
//            avatar.SetBool("Slip", rand == 20);
//            avatar.SetBool("GameWin", rand == 20); // This one like to make a aisatsu
        }
	}
}
