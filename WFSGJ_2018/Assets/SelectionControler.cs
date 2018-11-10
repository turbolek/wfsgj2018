using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionControler : MonoBehaviour
{
    public Player.PlayerID player;
    public CharacterSelect characterSelect;

    string _verticalAxisName = "";
    string _horizontalAxisName = "";
    string _confirmString = "";
    string _cancelString = "";
    bool _inputBlocked;

    private void Start()
    {
        switch (player)
        {
            case Player.PlayerID.Player1:
                {
                    _verticalAxisName = "Player1_Vertical";
                    _horizontalAxisName = "Player1_Horizontal";
                    _confirmString = "Player1_Confirm";
                    _cancelString = "Player1_Cancel";
                    break;
                }
            case Player.PlayerID.Player2:
                {
                    _verticalAxisName = "Player2_Vertical";
                    _horizontalAxisName = "Player2_Horizontal";
                    _confirmString = "Player2_Confirm";
                    _cancelString = "Player2_Cancel";
                    break;
                }
        }
    }

    private void Update()
    {
        if (!_inputBlocked)
        {
            Move();
            OnConfirm();
            OnCancel();
        }
    }

    void Move()
    {
        float horizontalAxis = Input.GetAxisRaw(_horizontalAxisName);
        float verticalAxis = Input.GetAxisRaw(_verticalAxisName);

        if (horizontalAxis > 0.2f)
        {
            characterSelect.MoveRight(player);
            StartCoroutine(BlockInput());
        }
        else if (horizontalAxis < -0.2f)
        {
            characterSelect.MoveLeft(player);
            StartCoroutine(BlockInput());
        }
        else if (verticalAxis > 0.2f)
        {
            characterSelect.MoveUp(player);
            StartCoroutine(BlockInput());
        }
        else if (verticalAxis < -0.2f)
        {
            characterSelect.MoveDown(player);
            StartCoroutine(BlockInput());
        }
    }

    void OnConfirm()
    {
        if (Input.GetButtonDown(_confirmString))
        {
            characterSelect.ChooseMem(player);
        }
    }

    void OnCancel()
    {
        if (Input.GetButtonDown(_cancelString))
        {
            characterSelect.CancelChooseMem(player);
        }
    }

    IEnumerator BlockInput()
    {
        _inputBlocked = true;
        yield return new WaitForSeconds(0.2f);
        _inputBlocked = false;
    }
}
