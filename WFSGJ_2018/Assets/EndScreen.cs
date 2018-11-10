using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : GameScreen
{
    public PlayerUI[] playersUI;

    public override void Show()
    {
        _blockInput = true;

        base.Show();

        for (int i = 0; i < playersUI.Length; i++)
        {
            playersUI[i].RefreshStatus();
        }

        StartCoroutine(WaitForInputUnlock());
    }

    private void Update()
    {
        if (_blockInput) return;

        if (Input.GetButtonDown("Player1_Confirm"))
        {
            Fader.Instance.StartBuffering(2, LoadScene);
            _blockInput = true;
        }
    }

    void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    bool _blockInput;
    IEnumerator WaitForInputUnlock()
    {
        yield return new WaitForSeconds(2);
        _blockInput = false;
    }
}
