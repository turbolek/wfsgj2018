using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeDisplay : MonoBehaviour
{
    public Player currentMemeOwner;

    public void AddDislike()
    {
        if (currentMemeOwner == null)
            return;

        currentMemeOwner.dislikeCount++;
        Debug.Log(currentMemeOwner.name + " dislikes : " + currentMemeOwner.dislikeCount.ToString());
    }

}
