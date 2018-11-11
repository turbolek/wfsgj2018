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
    Animator animator;

    public void Select()
    {
        if (_active) _active.Diselect();
        _active = this;
        animator.SetBool("selected", true);
        //button.color = colors[1];
    }

    public void Diselect()
    {
        animator.SetBool("selected", false);
        //button.color = colors[0];
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

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
