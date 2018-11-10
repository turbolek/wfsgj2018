using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemSlot : MonoBehaviour
{
    public Image memImage, hover;
    public Color[] hoverColor;
    public bool choosed;

    Material _material;
    int _grayPropertyId;

    private void Awake()
    {
        _material = new Material(memImage.material);
        memImage.material = _material;
        _grayPropertyId = Shader.PropertyToID("_GrayAmount");
        hover.enabled = false;
    }    

    public void SetMem(Sprite mem)
    {
        memImage.sprite = mem;
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
        SetGrayed(true);
    }

    public void CancelChoose()
    {
        choosed = false;
        SetGrayed(false);
    }

    public void SetGrayed(bool state)
    {
        if (!memImage || !_material) return;
        _material.SetFloat(_grayPropertyId, state == true ? 1f : 0f);
    }
}
