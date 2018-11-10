using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : GameScreen
{
    public ButtonUI[] buttons;

    private void Update()
    {
        if (Input.GetAxisRaw("Player1_Vertical") > 0.2) buttons[0].Select();
        else if (Input.GetAxisRaw("Player1_Vertical") < -0.2f) buttons[1].Select();

        if (Input.GetButtonDown("Player1_Confirm")) ButtonUI.OnClickActive();
    }

    public override void Show()
    {
        base.Show();
        buttons[0].Select();
    }

    public void OnPlayButton()
    {
        GameManager.Instance.ShowScreen(ScreenType.characterSelect, false);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
