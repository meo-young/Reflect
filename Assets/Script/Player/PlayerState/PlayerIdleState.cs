using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    public void OnStateEnter(PlayerController npcController)
    {
        if (!_playerController)
            _playerController = npcController;
    }
    public void OnStateUpdate()
    {
        //Debug.Log("Player Idle");
        // ����Ű �Է½� Walking���� ���� ����
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            _playerController.ChangeState(_playerController._walkState);
        }

    }

    public void OnStateExit()
    {

    }

}
