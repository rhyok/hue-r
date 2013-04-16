using UnityEngine;

public class PhysicsPlayer : MonoBehaviour
{

    public static float distanceTraveled;

    public Vector3 acceleration;
    public Vector3 jumpVelocity;

    public bool touchingPlatform;

    void Update()
    {
        if (touchingPlatform && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }

        if (Input.GetButton("Horizontal"))
        {
            rigidbody.AddForce(acceleration * Input.GetAxis("Horizontal"), ForceMode.Acceleration);
        }
        distanceTraveled = transform.localPosition.x;
    }

    void FixedUpdate()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal * 10.0f, Color.red, 1200.0f, true);
        //}
        Debug.Log("Touching " + collision.collider.name);
        touchingPlatform = true;
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("No longer touching " + collision.collider.name);
        touchingPlatform = false;
    }
}