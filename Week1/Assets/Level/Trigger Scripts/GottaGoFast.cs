using UnityEngine;
using System.Collections;

public class GottaGoFast : MonoBehaviour {
    public Transform exitLocation;
    public float entrySpeed;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (other.transform.gameObject.rigidbody.velocity.x > entrySpeed)
            {
                other.transform.position = new Vector3(exitLocation.position.x, other.transform.position.y, other.transform.position.z);
            }
        }
    }
}
