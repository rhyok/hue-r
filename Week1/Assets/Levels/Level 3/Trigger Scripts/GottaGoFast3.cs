using UnityEngine;
using System.Collections;

public class GottaGoFast3 : MonoBehaviour {
    public Transform backExit;
    public float entrySpeed;
    public string goToLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Speed: " + other.rigidbody.velocity.y);
            other.transform.position = new Vector3(other.transform.position.x, backExit.position.y, other.transform.position.z);
            other.rigidbody.velocity = new Vector3(other.rigidbody.velocity.x, other.rigidbody.velocity.y < -100.0f ? -100.0f : other.rigidbody.velocity.y * 1.1f, 0.0f);
        }
    }
}
