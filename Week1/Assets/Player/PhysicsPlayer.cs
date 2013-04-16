using UnityEngine;
using System;

public class PhysicsPlayer : MonoBehaviour
{

    public static float distanceTraveled;

    public Vector3 acceleration;
    public Vector3 jumpVelocity;

    public bool touchingPlatform;
    private Collision collision;

    void Update()
    {
        if (touchingPlatform && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
            if (collision != null)
            {
                float horizontalMag = Math.Abs(collision.contacts[0].normal.x);
                float verticalMag = Math.Abs(collision.contacts[0].normal.y);

                String dir = "";

                if (horizontalMag > verticalMag)
                {
                    dir = collision.contacts[0].normal.x < 0 ? "right" : "left";
                }

                rigidbody.AddForce(acceleration * (dir.Equals("right")? -5 : dir.Equals("left") ? 5 : 0), ForceMode.Acceleration);
            }
            touchingPlatform = false;
        }

        if (Input.GetButton("Horizontal"))
        {
            rigidbody.AddForce(acceleration * Input.GetAxis("Horizontal") * (touchingPlatform?1.0f:0.75f), ForceMode.Acceleration);
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
        this.collision = collision;
        Debug.Log("Touching " + collision.collider.name);
        touchingPlatform = true;
    }

    void OnCollisionStay(Collision collision)
    {
        this.collision = collision;
        touchingPlatform = true;
    }

    void OnCollisionExit(Collision collision)
    {
        this.collision = collision;
        Debug.Log("No longer touching " + collision.collider.name);
        touchingPlatform = false;
    }
}