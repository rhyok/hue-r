using UnityEngine;
using System.Collections;

public class UserDisplay : MonoBehaviour {
    
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");
        if (GUI.Button(new Rect(20, 40, 80, 20), "Hello world!"))
        {
            print("Hello world. :3");
        }
    }
}
