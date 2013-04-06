using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Move
{
    LEFT,
    RIGHT,
    JUMP
}

public class Player : MonoBehaviour {
    public string   JumpKey         = "x";
    public string   LeftKey         = "left";
    public string   RightKey        = "right";

    public float    movespeedCap    = 0.2f;
    public float    movespeed       = 0.005f;
    public float    friction        = 0.10f;
    public float    xTranslation    = 0;
    public float    yTranslation    = 0;

    private ArrayList movement = new ArrayList();

    public Transform playerObject;

    void Update()
    {
        CheckKeys();
        MovePlayer();
        ResolveCollisions();
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

    void MovePlayer()
    {
        foreach (Move m in movement)
        {
            switch (m)
            {
                case Move.LEFT:
                    if(xTranslation > -movespeedCap)
                    {
                        if (xTranslation > 0)
                        {
                            xTranslation -= friction*2;
                        }
                        //Debug.Log("Left pressed");
                        xTranslation -= movespeed;
                    }
                    break;
                case Move.RIGHT:
                    if (xTranslation < movespeedCap)
                    {
                        if (xTranslation < 0)
                        {
                            xTranslation += friction*2;
                        }
                        //Debug.Log("Right pressed");
                        xTranslation += movespeed;
                    }
                    break;
            }
        }

        //Movement friction
        if (!movement.Contains(Move.LEFT) && !movement.Contains(Move.RIGHT))
        {
            //Debug.Log("Entered into friction");
            if (xTranslation > 0)
            {
                xTranslation -= friction;
                //Just stahp if we've gone negative
                if (xTranslation < 0)
                    xTranslation = 0;
            }
            if (xTranslation < 0)
            {
                xTranslation += friction;
                //Just stahp if we've gone positive
                if (xTranslation > 0)
                    xTranslation = 0;
            }
        }
        movement.Clear();
        playerObject.Translate(new Vector3(xTranslation, 0f, 0f));
    }

    void ResolveCollisions()
    {

    }
}
