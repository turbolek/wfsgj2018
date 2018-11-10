﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeDisplay : MonoBehaviour
{
    Image image;
    AudioSource audioSource;
    public PlayerUI[] playerUIs;
    public GameplayManager gameplayManager;

    public Slider slider;
    public Text timeLabel;
    float timer = 0f;

    private void Start()
    {
        image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    Player currentMemeOwner;

    public void AddDislike()
    {
        if (currentMemeOwner == null)
            return;

        currentMemeOwner.dislikeCount++;
        Debug.Log(currentMemeOwner.name + " dislikes : " + currentMemeOwner.dislikeCount.ToString());
        foreach (PlayerUI playerUI in playerUIs)
        {
            if (playerUI.player == currentMemeOwner)
                playerUI.Refresh();
        }

        if (currentMemeOwner.dislikeCount >= gameplayManager.playersHealth)
            gameplayManager.FinishGame();
    }

    public void RefreshMeme(Meme meme)
    {
        currentMemeOwner = meme.player;
        Debug.Log("new meme. owner: " + currentMemeOwner.name);
        image.sprite = meme.sprite;
        audioSource.clip = meme.audioClip;
        audioSource.Play();
        timer = 0f;
    }

    private void Update()
    {
        if (currentMemeOwner == null)
            return;

        timeLabel.text = "00:" + ((int)timer).ToString(("D2"));
        slider.value = timer / gameplayManager.memeLifetime;
        timer += Time.deltaTime;
    }
}
