using UnityEngine;

public class PhysicsPlayer : MonoBehaviour
{

    public static float distanceTraveled;

    public Vector3 acceleration;
    public Vector3 jumpVelocity;

    private bool touchingPlatform;

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
        touchingPlatform = true;
    }

    void OnCollisionExit(Collision collision)
    {
        touchingPlatform = false;
    }
}