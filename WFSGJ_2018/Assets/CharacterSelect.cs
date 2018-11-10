using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameplayManager gameplayManager;

    MemSlot[] _slots;

    public SelectedSlots[] playerMems;

    int[] playerChoose = new int[] { 0, 3 };
    string verticalAxisName = "";
    string horizontalAxisName = "";

    public void Start()
    {
        _slots = GetComponentsInChildren<MemSlot>();

        for (int i = 0; i < playerChoose.Length; i++)
        {
            SelectSlot((Player.PlayerID)i, playerChoose[i]);
        }
    }

    public bool PlayersAreReady()
    {
        for (int i = 0; i < playerChoose.Length; i++)
        {
            if (!playerMems[i].IsReady) return false;
        }

        return true;
    }

    public void ChooseMem(Player.PlayerID player)
    {
        var mems = playerMems[(int)player];

        if (mems.selectedSlot.Count >= mems.slot.Length || _slots[playerChoose[(int)player]].choosed
            || !_slots[playerChoose[(int)player]].avaiable) return;

        _slots[playerChoose[(int)player]].ChooseMem(player);
        mems.selectedSlot.Add(_slots[playerChoose[(int)player]]);
        mems.slot[mems.selectedSlot.Count - 1].enabled = true;
        mems.slot[mems.selectedSlot.Count - 1].sprite = _slots[playerChoose[(int)player]].memImage.sprite;
    }

    public void CancelChooseMem(Player.PlayerID player)
    {
        var mems = playerMems[(int)player];

        if (mems.selectedSlot.Count == 0) return;

        mems.selectedSlot[mems.selectedSlot.Count - 1].CancelChoose();
        mems.selectedSlot.RemoveAt(mems.selectedSlot.Count - 1);
        mems.slot[mems.selectedSlot.Count].sprite = null;
        mems.slot[mems.selectedSlot.Count].enabled = false;
    }

    public void MoveRight(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] + 1;

        if (index >= _slots.Length)
            return;

        SelectSlot(player, index);
    }

    public void MoveLeft(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] - 1;

        if (index < 0)
            return;

        SelectSlot(player, index);
    }

    public void MoveUp(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] - 4;

        if (index < 0)
        {
            return;
        }

        SelectSlot(player, index);
    }

    public void MoveDown(Player.PlayerID player)
    {
        var index = playerChoose[(int)player] + 4;

        if (index >= _slots.Length)
        {
            return;
        }

        SelectSlot(player, index);
    }

    void SelectSlot(Player.PlayerID player, int index)
    {
        _slots[playerChoose[(int)player]].DiselectMem(player);
        playerChoose[(int)player] = index;
        _slots[index].SelectMem(player);
    }

    public void StartGame()
    {
        GameManager.Instance.ShowScreen(ScreenType.gameplay);
        gameplayManager.SetMemes(playerMems[0], playerMems[1]);
    }
}

[System.Serializable]
public class SelectedSlots
{
    public List<MemSlot> selectedSlot;
    public Image[] slot;

    public bool IsReady { get { return selectedSlot.Count == slot.Length; } }
}