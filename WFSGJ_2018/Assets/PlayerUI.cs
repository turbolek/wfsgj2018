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
    public Text dislikesCount;
    Animator animator;

    public GameplayManager gameplayManager;

    public bool refreshOnStart = true;

    private void Start()
    {
        if (refreshOnStart)
        {
            avatarImage.sprite = avaterState[0];
            greenBar.fillAmount = 1;
        }
        animator = GetComponent<Animator>();
    }

    public void Refresh()
    {
        if (animator != null)
            animator.SetTrigger("healthBar_wobble");
        RefreshStatus();
    }

    public void RefreshStatus()
    {
        var percent = 1 - (float)player.dislikeCount / gameplayManager.playersHealth;
        greenBar.fillAmount = Mathf.Clamp01(percent);
        dislikesCount.text = player.dislikeCount.ToString();

        if (percent < 0.25f) avatarImage.sprite = avaterState[2];
        else if (percent < 0.6f) avatarImage.sprite = avaterState[1];
    }
}
