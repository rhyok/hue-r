using UnityEngine;
using System.Collections;

public class trigger_EndLevel2 : MonoBehaviour {
    public string goToLevel;
	
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Level 2 should be done now");
            Application.LoadLevel(goToLevel);
        }
    }
}
