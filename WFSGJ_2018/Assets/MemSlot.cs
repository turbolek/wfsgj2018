using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemSlot : MonoBehaviour
{
    public bool avaiable = true;

    public Image memeImage;
    public AudioClip memeMusic;
    public Image[] hover = new Image[2];
    public bool choosed;

    Material _material;
    int _grayPropertyId;

    private void Awake()
    {
        _material = new Material(memeImage.material);
        memeImage.material = _material;
        _grayPropertyId = Shader.PropertyToID("_GrayAmount");
        for (int i = 0; i < hover.Length; i++)
        {
            hover[i].enabled = false;
        }
    }

    public void SetMem(Sprite mem)
    {
        memeImage.sprite = mem;
    }

    public void SelectMem(Player.PlayerID player)
    {
        hover[(int)player].enabled = true;
        CheckHoverFill();
    }

    public void DiselectMem(Player.PlayerID player)
    {
        hover[(int)player].enabled = false;
        CheckHoverFill();
    }

    void CheckHoverFill()
    {
        if (hover[0].enabled && hover[1].enabled)
        {
            hover[1].fillAmount = 0.5f;
        }
        else
        {
            hover[1].fillAmount = 1;
        }
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
        if (!memeImage || !_material) return;
        _material.SetFloat(_grayPropertyId, state == true ? 1f : 0f);
    }
}
