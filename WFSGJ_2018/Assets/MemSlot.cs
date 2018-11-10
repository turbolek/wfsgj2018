using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemSlot : MonoBehaviour
{
    public Image hover;
    public Color[] hoverColor;

    public bool choosed;

    private void Awake()
    {
        hover.enabled = false;
    }

    public void SelectMem(Player.PlayerID player)
    {
        hover.color = hoverColor[(int)(player)];
        hover.enabled = true;
    }

    public void DiselectMem()
    {
        hover.enabled = false;
    }

    public void ChooseMem(Player.PlayerID player)
    {
        choosed = true;
    }

    public void CancelChoose()
    {
        choosed = false;
    }
}
