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
    public int playersHealth;

    int currentMemeIndex = 0;

    public void SetMemes(SelectedSlots player1, SelectedSlots player2)
    {
        for (int i = 0; i < player1.selectedSlot.Count; i++)
        {
            memes[2 * i].sprite = player1.selectedSlot[i].memeImage.sprite;
            memes[2 * i].audioClip = player1.selectedSlot[i].memeMusic;
        }

        for (int i = 0; i < player2.selectedSlot.Count; i++)
        {
            memes[2 * i + 1].sprite = player2.selectedSlot[i].memeImage.sprite;
            memes[2 * i + 1].audioClip = player2.selectedSlot[i].memeMusic;
        }
    }

    private void Start()
    {
        currentMemeIndex = 0;
    }

    private void Update()
    {
        if (memes.Count < 1)
            return;
        if (currentMeme == null)
            SetNextMeme();

        if (timer > memeLifetime)
        {
            SetNextMeme();
        }
        timer += Time.deltaTime;
    }

    void SetNextMeme()
    {
        if (memes.Count > currentMemeIndex)
        {
            currentMeme = memes[currentMemeIndex];
            currentMemeIndex++;
            timer = 0f;
            memeDisplay.RefreshMeme(currentMeme);
        }
        else
            FinishGame();

    }

    public void FinishGame()
    {
        GameManager.Instance.ShowScreen(ScreenType.endScreen, false);
    }
}
