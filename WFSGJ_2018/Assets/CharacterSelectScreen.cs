using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScreen : GameScreen
{
    public CharacterSelect characterSelect;

    public override void Show()
    {
        base.Show();
        characterSelect.ResetSelection();
    }
}
