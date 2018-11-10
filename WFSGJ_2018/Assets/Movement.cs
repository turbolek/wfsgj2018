using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float maxVelocity;
    public float acceleration;
    public float velocityDrag;
    
    float velocityX;
    float velocityY;

    string verticalAxisName = "";
    string horizontalAxisName = "";

    Rigidbody rb;

    // Use this for initialization
    void Start () {
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
                    break;
                }
            case Player.PlayerID.Player2:
                {
                    verticalAxisName = "Player2_Vertical";
                    horizontalAxisName = "Player2_Horizontal";
                    break;
                }
        }
	}
	
	// Update is called once per frame
	void Update () {
        ManageMovement();
      // ApplyDrag();
	}

    void ManageMovement()
    {
        float horizontalAxis = Input.GetAxisRaw(horizontalAxisName);
        float verticalAxis = Input.GetAxisRaw(verticalAxisName);

        velocityX = Mathf.Clamp(velocityX + horizontalAxis * acceleration, -maxVelocity, maxVelocity);
        velocityY = Mathf.Clamp(velocityY + verticalAxis * acceleration, -maxVelocity, maxVelocity);

        rb.velocity += new Vector3(velocityX, velocityY) * Time.deltaTime;
    }

    void ApplyDrag()
    {
        if (velocityX > velocityDrag)
            velocityX -= velocityDrag;
        else if (velocityX < -velocityDrag)
            velocityX += velocityDrag;
        else
            velocityX = 0;

        if (velocityY > velocityDrag)
            velocityY -= velocityDrag;
        else if (velocityY < -velocityDrag)
            velocityY += velocityDrag;
        else
            velocityY = 0;
    }
}
