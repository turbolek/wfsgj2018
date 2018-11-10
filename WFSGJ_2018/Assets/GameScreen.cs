using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    mainMenu,
    characterSelect,
    gameplay,
    endScreen
}

public class GameScreen : MonoBehaviour
{
    static GameScreen _activeScreen;

    [SerializeField]
    ScreenType _screenType;

    public ScreenType ScreenType { get { return _screenType; } }

    public virtual void Show()
    {
        if (_activeScreen) _activeScreen.Hide();
        gameObject.SetActive(true);
        _activeScreen = this;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
