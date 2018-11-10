using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    public GameObject redBar;
    public Player player;

    GameplayManager gameplayManager;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        redBar.transform.localScale = new Vector3(0f, 1f, 1f);
    }

    public void Refresh()
    {
        redBar.transform.localScale = new Vector3(Mathf.Clamp((float) player.dislikeCount / gameplayManager.playersHealth, 0f, 1f), 1f, 1f);
    }

}
