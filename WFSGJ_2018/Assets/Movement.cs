﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const float controllerDeadZone = .2f;
    const float stopTreshold = .1f;

    public float maxVelocity;
    public float acceleration;
    public float velocityDrag;

    float velocityX;
    float velocityY;

    string verticalAxisName = "";
    string horizontalAxisName = "";
    string clickName = "";

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        Player player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        if (player == null)
            return;

        switch (player.playerID)
        {
            case Player.PlayerID.Player1:
                {
                    verticalAxisName = "Player1_Vertical";
                    horizontalAxisName = "Player1_Horizontal";
                    clickName = "Player1_Click";
                    break;
                }
            case Player.PlayerID.Player2:
                {
                    verticalAxisName = "Player2_Vertical";
                    horizontalAxisName = "Player2_Horizontal";
                    clickName = "Player2_Click";
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        CheckClick();
    }

    void CheckClick()
    {
        if (Input.GetButtonDown(clickName))
        {
            print("click");
        }
    }

    void ManageMovement()
    {
        float horizontalAxis = Input.GetAxisRaw(horizontalAxisName);
        float verticalAxis = Input.GetAxisRaw(verticalAxisName);

        bool horizontalAxisIdle = Mathf.Abs(horizontalAxis) < controllerDeadZone;
        bool verticalAxisIdle = Mathf.Abs(verticalAxis) < controllerDeadZone;

        float accelerationX = 0f;
        float accelerationY = 0f;

        if (horizontalAxisIdle)
            accelerationX = GetDrag(rb.velocity.x);
        else
            accelerationX = horizontalAxis * acceleration;

        if (verticalAxisIdle)
            accelerationY = GetDrag(rb.velocity.y);
        else
            accelerationY = verticalAxis * acceleration;

        velocityX = Mathf.Clamp(rb.velocity.x + accelerationX * Time.deltaTime, -maxVelocity, maxVelocity);
        velocityY = Mathf.Clamp(rb.velocity.y + accelerationY * Time.deltaTime, -maxVelocity, maxVelocity);

        if (horizontalAxisIdle && Mathf.Abs(velocityX) < stopTreshold)
            velocityX = 0f;
        if (verticalAxisIdle && Mathf.Abs(velocityY) < stopTreshold)
            velocityY = 0f;

        rb.velocity = new Vector3(velocityX, velocityY);
    }


    float GetDrag(float velocity)
    {
        if (velocity == 0f)
            return 0f;

        float drag = velocityDrag * -velocity / Mathf.Abs(velocity);

        return drag;
    }
}
