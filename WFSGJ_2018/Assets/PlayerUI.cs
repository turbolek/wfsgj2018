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

    GameplayManager gameplayManager;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        //greenBar.transform.localScale = new Vector3(0f, 1f, 1f);
        greenBar.fillAmount = 1;
    }

    public void Refresh()
    {
        var percent = (float)player.dislikeCount / gameplayManager.playersHealth;
        greenBar.fillAmount = Mathf.Clamp01(percent);

        if (percent < 0.6f) avatarImage.sprite = avaterState[1];
        else if (percent < 0.25f) avatarImage.sprite = avaterState[2];
    }

}
