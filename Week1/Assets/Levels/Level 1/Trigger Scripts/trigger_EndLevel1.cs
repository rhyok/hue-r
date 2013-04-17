using UnityEngine;
using System.Collections;

public class trigger_EndLevel1 : MonoBehaviour {
    public string goToLevel;
	
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Application.LoadLevel(goToLevel);
        }
    }
}
