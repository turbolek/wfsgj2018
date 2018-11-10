using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameplayManager: MonoBehaviour {

    public List<Meme> memes = new List<Meme>();
    public Meme currentMeme;
    public float memeLifetime;
    float timer = 0f;
    public MemeDisplay memeDisplay;

    private void Update()
    {
        if (memes.Count < 1)
            return;
        if (currentMeme = null)
            currentMeme = memes[0];

        if (timer > memeLifetime)
        {
            currentMeme = GetNextMeme();
            memeDisplay.RefreshMeme(currentMeme);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    Meme GetNextMeme()
    {
        Meme meme = memes[Random.Range(0, memes.Count)];
        return meme;
    }
}
