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
    [HideInInspector]
    public Animator animator;

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
        animator = GetComponent<Animator>();
    }

    public void SetMem(Sprite mem)
    {
        memeImage.sprite = mem;
    }

    public void SelectMem(Player.PlayerID player)
    {
        hover[(int)player].enabled = true;
        CheckHoverFill();
        animator.SetTrigger("highlight");
    }

    public void DiselectMem(Player.PlayerID player)
    {
        hover[(int)player].enabled = false;
        CheckHoverFill();
        animator.SetTrigger("release");
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
        animator.SetTrigger("select");
        choosed = true;
        SetGrayed(true);
    }

    public void CancelChoose()
    {
        animator.SetTrigger("cancel");
        choosed = false;
        SetGrayed(false);
    }

    public void SetGrayed(bool state)
    {
        if (!memeImage || !_material) return;
        _material.SetFloat(_grayPropertyId, state == true ? 1f : 0f);
    }
}
