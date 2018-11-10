using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameplayManager : MonoBehaviour
{
    public List<Meme> memes = new List<Meme>();
    public Meme currentMeme;
    public float memeLifetime;
    float timer = 0f;
    public MemeDisplay memeDisplay;

    public void SetMemes(SelectedSlots player1, SelectedSlots player2)
    {
        for (int i = 0; i < player1.selectedSlot.Count; i++)
        {
            memes[i].sprite = player1.selectedSlot[i].memImage.sprite;
        }

        for (int i = 0; i < player2.selectedSlot.Count; i++)
        {
            memes[i].sprite = player2.selectedSlot[i].memImage.sprite;
        }
    }

    private void Update()
    {
        if (memes.Count < 1)
            return;
        if (currentMeme = null)
            SetNextMeme();

        if (timer > memeLifetime)
        {
            SetNextMeme();
        }
        timer += Time.deltaTime;
    }

    void SetNextMeme()
    {
        Meme meme = memes[Random.Range(0, memes.Count)];
        timer = 0f;
        currentMeme = meme;
        memeDisplay.RefreshMeme(currentMeme);
    }
}
