using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Meme : MonoBehaviour {

    public Player.PlayerID playerID;
    public Sprite sprite;
    public AudioClip audioClip;
    [HideInInspector]
    public Player player;

    private void Start()
    {
        Player[] players = FindObjectsOfType<Player>();
        foreach (Player pl in players)
        {
            if (pl.playerID == playerID)
            {
                player = pl;
                return;
            }

        }
    }
}
