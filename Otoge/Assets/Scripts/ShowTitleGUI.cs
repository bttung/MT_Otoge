using UnityEngine;
using System.Collections;

public class ShowTitleGUI : MonoBehaviour {

    public string title = "";
    public GUISkin guiStyle;
    
    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0 || Input.anyKey) {
            Application.LoadLevel("Menu");
        }
    }
    
    void OnGUI() {
        GUI.skin = guiStyle;
        GUI.Box(new Rect(10.0f, 30.0f, Screen.width - 20.0f, Screen.height - 20.0f), title);
    }

}
