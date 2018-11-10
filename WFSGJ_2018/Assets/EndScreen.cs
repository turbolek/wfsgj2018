using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : GameScreen
{
    public PlayerUI[] playersUI;

    public override void Show()
    {
        base.Show();

        for (int i = 0; i < playersUI.Length; i++)
        {
            playersUI[i].Refresh();
        }
    }
}
