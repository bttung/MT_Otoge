using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pose {
    public static string IDLE1 = "IDLE1";   // POSE01
    public static string IDLE2 = "IDLE2";   // POSE02
    public static string DANCE1 = "DANCE1";
    public static string DANCE2 = "DANCE2";
    public static string DANCE3 = "DANCE3";
    public static string DANCE_EXCELLENT = "DANCE4";
    public static string SLIPPED1 = "SLIPPED1";

    // Get the pose action depends on level
    public static List<string> GetPoseList(int level) {
        if (level < 0) {
            Debug.LogError("Pose: This level is invalid");
            return null;
        }

        List<string> goodPose = new List<string>();
        goodPose.Add(DANCE1);
        goodPose.Add(DANCE2);
        goodPose.Add(DANCE3);

        if (level > goodPose.Count) {
            return goodPose;
        } else if (level == 0) {
            return goodPose.GetRange(0, 1);
        } else {
            return goodPose.GetRange(0, level);
        }
    }
}
