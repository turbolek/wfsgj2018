using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Sprite[] avaterState;
    public Image avatarImage;

    public Image greenBar;
    public Player player;
    Animator animator;

    GameplayManager gameplayManager;

    private void Start()
    {
        avatarImage.sprite = avaterState[0];
        gameplayManager = FindObjectOfType<GameplayManager>();
        greenBar.fillAmount = 1;
        animator = GetComponent<Animator>();
    }

    public void Refresh()
    {
        animator.SetTrigger("healthBar_wobble");

        var percent = 1 - (float)player.dislikeCount / gameplayManager.playersHealth;
        Debug.Log("Percent:" + percent);
        greenBar.fillAmount = Mathf.Clamp01(percent);

        if (percent < 0.6f) avatarImage.sprite = avaterState[1];
        else if (percent < 0.25f) avatarImage.sprite = avaterState[2];

    }

}
