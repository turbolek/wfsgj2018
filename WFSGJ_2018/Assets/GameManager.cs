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
        ShowScreen(ScreenType.characterSelect);
    }

    public void ShowScreen(ScreenType screen)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i].ScreenType == screen)
            {
                _screenIndex = i;
                Fader.Instance.StartBuffering(2, SwitchScreen);
            }
        }
    }

    void SwitchScreen()
    {
        screens[_screenIndex].Show();
    }
}
