using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    MemSlot[] _slots;

    int[] playerChoose = new int[] { 0, 3 };

    string verticalAxisName = "";
    string horizontalAxisName = "";

    public void Start()
    {
        _slots = GetComponentsInChildren<MemSlot>();
        SelectSlot((Player.PlayerID)0, playerChoose[0]);
        SelectSlot((Player.PlayerID)1, playerChoose[1]);
    }

    public void ChooseMem(Player.PlayerID player)
    {
        _slots[playerChoose[(int)player]].ChooseMem(player);
    }

    public void MoveRight(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] + 1;

        if (index < _slots.Length && (_slots[index].choosed || _slots[index].hover.enabled))
        {
            index++;
        }

        if (index >= _slots.Length)
        {
            return;
        }

        SelectSlot(player, index);
    }

    public void MoveLeft(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] - 1;

        if (index > 0 && (_slots[index].choosed || _slots[index].hover.enabled))
        {
            index--;
        }

        if (index < 0)
        {
            return;
        }

        SelectSlot(player, index);
    }

    public void MoveUp(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] - 4;

        if (index > 0 && (_slots[index].choosed || _slots[index].hover.enabled))
        {
            index -= 4;
        }

        if (index < 0)
        {
            return;
        }

        SelectSlot(player, index);
    }

    public void MoveDown(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] + 4;

        if (index < _slots.Length && (_slots[index].choosed || _slots[index].hover.enabled))
        {
            index += 4;
        }

        if (index >= _slots.Length)
        {
            return;
        }

        SelectSlot(player, index);
    }

    void SelectSlot(Player.PlayerID player, int index)
    {
        _slots[playerChoose[(int)player]].DiselectMem();
        playerChoose[(int)player] = index;
        _slots[index].SelectMem(player);
    }
}