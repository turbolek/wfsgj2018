using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameScreen[] screens;

    int _screenIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (GameScreen screen in screens)
            screen.Hide();
        ShowScreen(ScreenType.characterSelect);
    }

    public void ShowScreen(ScreenType screen, bool showBuffering = true)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i].ScreenType == screen)
            {
                _screenIndex = i;
                if (showBuffering)
                    Fader.Instance.StartBuffering(2, SwitchScreen);
                else
                    SwitchScreen();
            }
        }
    }

    void SwitchScreen()
    {
        screens[_screenIndex].Show();
    }
}
