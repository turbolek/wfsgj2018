using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DislikeButton : MonoBehaviour
{

    public MemeDisplay memeDisplay;

    public void Click()
    {
        Debug.Log("Dislike button clicked");
        if (memeDisplay == null)
        {
            Debug.LogError("You must assign meme display to Dislike Button!");
            return;
        }

        memeDisplay.AddDislike();
    }
}
