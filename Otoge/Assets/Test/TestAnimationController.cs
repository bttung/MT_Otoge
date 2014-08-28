using UnityEngine;
using System.Collections;

public class TestAnimationController : MonoBehaviour {

    protected Animator avatar;

	// Use this for initialization
	void Start () {
        avatar = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (avatar) {
            int rand = Random.Range(0, 50);

            // avatar.SetBool("Pose1", rand == 20); // well, she bring both hand infront
           // avatar.SetBool("Pose2", rand == 20);  // She dance well
//            avatar.SetBool("Pose3", rand == 20);  // this is like dance
//            avatar.SetBool("Pose4", rand == 20);    // Good she bring up one leg
//            avatar.SetBool("Pose5", rand == 20); 
//            avatar.SetBool("Pose6", rand == 20); // She slipped award
//            avatar.SetBool("Pose7", rand == 20);  // Jump to left
            //avatar.SetBool("Pose8", rand == 20); // Slipped to the right
//            avatar.SetBool("Pose9", rand == 20); // Flipped the right leg behind
//            avatar.SetBool("Pose10", rand == 20); // Slipped to right behind
//            avatar.SetBool("Pose11", rand == 20); // Jump with left hand, and right leg
//            avatar.SetBool("Pose12", rand == 20); // slip leg to horizontal axis, bring up hand

//            avatar.SetBool("HANDUP00_R", rand == 20); // Not good
//            avatar.SetBool("JUMP00", rand == 20); // Jump a little
//            avatar.SetBool("JUMP00B", rand == 20); // Jump a bring head low ahead
//            avatar.SetBool("JUMP01", rand == 20); // bring the body down, ahead
//            avatar.SetBool("JUMP01B", rand == 20); // dance a little
//            avatar.SetBool("LOSE00", rand == 20); // Not good

//            avatar.SetBool("REFLESH00", rand == 20); // Some thing like she is making MONKU 
//            avatar.SetBool("SLIDE00", rand == 20); // She run after ward, not slide
//            avatar.SetBool("WIN00", rand == 20); // Not good
//            avatar.SetBool("WAIT04", rand == 20); // She turn from right to left
//            avatar.SetBool("WAIT03", rand == 20); // She bring the shouder down
//            avatar.SetBool("WAIT02", rand == 20); // Turn from left to right
//            avatar.SetBool("WAIT01", rand == 20); // slide the right leg a little
        }
	}
}
