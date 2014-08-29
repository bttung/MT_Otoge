using UnityEngine;
using System.Collections;

public class CustomStyle {

    static GUIStyle myStyle;

    public static GUIStyle GetStyle() {
        myStyle = new GUIStyle();
        myStyle.fontSize = 50;
//        myStyle.fontStyle = FontStyle.Bold;
        myStyle.normal.textColor = Color.red;
        return myStyle;
    }

}
