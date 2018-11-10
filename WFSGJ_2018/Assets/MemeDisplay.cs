﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeDisplay : MonoBehaviour
{
    Image image;
    AudioSource audioSource;
    public PlayerUI[] playerUIs;

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
            playerUI.Refresh();
        }
    }

    public void RefreshMeme(Meme meme)
    {
        currentMemeOwner = meme.player;
        Debug.Log("new meme. owner: " + currentMemeOwner.name);
        image.sprite = meme.sprite;
        audioSource.clip = meme.audioClip;
        audioSource.Play();
 
    }
}