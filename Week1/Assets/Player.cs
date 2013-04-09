using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Move
{
    LEFT,
    RIGHT,
    JUMP,
    GRAVITY
}

public class Player : MonoBehaviour {
    public string   JumpKey         = "x";
    public string   LeftKey         = "left";
    public string   RightKey        = "right";

    public float    movespeedCap    = 0.2f;
    public float    movespeed       = 0.005f;
    public float    friction        = 0.10f;
    public float    xSpeed    		= 0;
    public float    ySpeed    		= 0;
    public float    gravity         = 0.01f;
    public float    fallCap         = -0.2f;

    private bool    isOnGround      = false;

    private ArrayList movement      = new ArrayList();
    private ArrayList collisions    = new ArrayList();

    public Transform playerObject;
	
	void OnCollisionEnter(Collision other)
	{
		//For box colliders only, the contact points are the corners of the box
		Debug.Log("Collision occurred");
		
		collisions.Add(other);
	}

    void Update()
    {
		ResolveCollisions();
        ApplyGravity();
        CheckKeys();
        MovePlayer();
    }

    void CheckKeys()
    {
        if (Input.GetKey(LeftKey) && !Input.GetKey(RightKey))
        {
            movement.Add(Move.LEFT);
        }
        if (Input.GetKey(RightKey) && !Input.GetKey(LeftKey))
        {
            movement.Add(Move.RIGHT);
        }
    }

    void ApplyGravity()
    {
        if (!isOnGround && ySpeed > fallCap)
        {
            ySpeed -= gravity;
        }
    }

    void MovePlayer()
    {
        foreach (Move m in movement)
        {
            switch (m)
            {
                case Move.LEFT:
                    if(xSpeed > -movespeedCap)
                    {
                        if (xSpeed > 0)
                        {
                            xSpeed -= friction*2;
                        }
                        //Debug.Log("Left pressed");
                        xSpeed -= movespeed;
                    }
                    break;
                case Move.RIGHT:
                    if (xSpeed < movespeedCap)
                    {
                        if (xSpeed < 0)
                        {
                            xSpeed += friction*2;
                        }
                        //Debug.Log("Right pressed");
                        xSpeed += movespeed;
                    }
                    break;
            }
        }

        //Movement friction
        if (!movement.Contains(Move.LEFT) && !movement.Contains(Move.RIGHT))
        {
            //Debug.Log("Entered into friction");
            if (xSpeed > 0)
            {
                xSpeed -= friction;
                //Just stahp if we've gone negative
                if (xSpeed < 0)
                    xSpeed = 0;
            }
            if (xSpeed < 0)
            {
                xSpeed += friction;
                //Just stahp if we've gone positive
                if (xSpeed > 0)
                    xSpeed = 0;
            }
        }
        movement.Clear();
        playerObject.Translate(new Vector3(xSpeed, ySpeed, 0f));
    }

    void ResolveCollisions()
    {
        foreach (Collision other in collisions)
        {
			foreach(ContactPoint cp in other.contacts)
			{
				//Let's only be concerned with the front-facing collisions
				if(cp.point.z < 0)
				{
					continue;
				}
				//Now we determine the type of collision.
				
				//Floor collision
				if(cp.point.y < transform.position.y)
				{
					isOnGround = true;
					ySpeed = 0;
					float trans = cp.otherCollider.bounds.max.y - cp.point.y;
					playerObject.Translate(new Vector3(0f, trans, 0f));
					break;
				}
			}
        }
        collisions.Clear();
    }
}
