using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Player
{
    using GOPair = Pair<GameObject, CollisionType>;

    public enum Move
    {
        LEFT,
        RIGHT,
        JUMP
    }

    public enum CollisionType
    {
        FLOOR,
        LEFT,
        RIGHT,
        CEILING
    }

    public class Pair<T1, T2>
    {
        private T1 left;
        private T2 right;

        public Pair(T1 l, T2 r)
        {
            this.left = l;
            this.right = r;
        }

        public T1 getLeft()
        {
            return left;
        }

        public T2 getRight()
        {
            return right;
        }

        public void setLeft(T1 l)
        {
            this.left = l;
        }

        public void setRight(T2 r)
        {
            this.right = r;
        }
    }



    public class Player : MonoBehaviour
    {
        public string JumpKey = "x";
        public string LeftKey = "left";
        public string RightKey = "right";

        public float movespeedCap = 0.2f;
        public float movespeed = 0.005f;
        public float friction = 0.10f;
        public float xSpeed = 0;
        public float ySpeed = 0;
        public float gravity = 0.01f;
        public float fallCap = -0.2f;

        public bool isOnGround = false;

        private ArrayList movement = new ArrayList(); //Contains Move.enum entries
        private ArrayList collisions = new ArrayList(); //Contains Collision type objects
        private ArrayList inContactWith = new ArrayList(); //Contains Pair<GameObject, enum CollisionType> entries, aliased as GOPair

        public Transform playerObject;

        void OnCollisionEnter(Collision other)
        {
            //For box colliders only, the contact points are the corners of the box
            Debug.Log("Collision occurred with " + other.gameObject.name);

            collisions.Add(other);
            inContactWith.Add(other.gameObject);
        }

        void OnCollisionExit(Collision other)
        {
            Debug.Log("No longer colliding with " + other.gameObject.name);
            inContactWith.Remove(other.gameObject);

            if (inContactWith.Count == 0)
            {
                isOnGround = false;
            }
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
                        if (xSpeed > -movespeedCap)
                        {
                            if (xSpeed > 0)
                            {
                                xSpeed -= friction * 2;
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
                                xSpeed += friction * 2;
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
            foreach (Collision c in collisions)
            {
                foreach (ContactPoint cp in c.contacts)
                {
                    //Determine collision type
                    if (cp.point.y < playerObject.transform.position.y)
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
}