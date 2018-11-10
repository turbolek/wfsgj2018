using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonUI : MonoBehaviour
{
    static ButtonUI _active;

    public Image button;
    public Color[] colors;

    public UnityEvent onClickEvent;

    public void Select()
    {
        if (_active) _active.Diselect();
        _active = this;
        button.color = colors[1];
    }

    public void Diselect()
    {
        button.color = colors[0];
    }

    public void OnClick()
    {
        if (_active == this && _active.gameObject.activeInHierarchy)
            onClickEvent.Invoke();
    }

    public static void OnClickActive()
    {
        if (_active) _active.OnClick();
    }
}
