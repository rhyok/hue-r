using UnityEngine;
using System.Collections;

public class GottaGoFast2 : MonoBehaviour {
    public Transform goalExit;
    public Transform backExit;
    public float entrySpeed;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (other.transform.gameObject.rigidbody.velocity.x > entrySpeed)
            {
                other.transform.position = new Vector3(goalExit.position.x, other.transform.position.y, other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3(backExit.position.x, other.transform.position.y, other.transform.position.z);
            }
        }
    }
}
