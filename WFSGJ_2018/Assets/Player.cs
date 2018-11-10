using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerID playerID;
    AudioSource audioSource;

    public int dislikeCount = 0;

    #region Controls
    string verticalAxisName = "";
    public string VerticalAxisName {  get { return verticalAxisName; } }

    string horizontalAxisName = "";
    public string HorizontalAxisName { get { return horizontalAxisName; } }
    
    string clickName = "";
    public string ClickName { get { return clickName; } }
    #endregion

    DislikeButton dislikeButton = null;

    public enum PlayerID
    {
        Player1,
        Player2
    }

    void CheckClick()
    {
        if (Input.GetButtonDown(clickName))
        {
            Debug.Log("Player: " + name + " clicked");
            if (dislikeButton != null)
                dislikeButton.Click();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(name + " entered trigger");
        dislikeButton = collision.GetComponent<DislikeButton>();
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log(name + " exit trigger");
        if (collision.GetComponent<DislikeButton>() == dislikeButton)
            dislikeButton = null;
    }

    private void Update()
    {
        CheckClick();
    }

    private void Start()
    {
        InitControls();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null && audioSource != null)
            audioSource.Play();
    }

    void InitControls()
    {
        switch (playerID)
        {
            case PlayerID.Player1:
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
}
