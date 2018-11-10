using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DislikeButton : MonoBehaviour
{

    public MemeDisplay memeDisplay;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        Debug.Log("Dislike button clicked");
        if (memeDisplay == null)
        {
            Debug.LogError("You must assign meme display to Dislike Button!");
            return;
        }

        audioSource.Play();
        memeDisplay.AddDislike();
    }
}
