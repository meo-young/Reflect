using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    public void OnStateEnter(PlayerController playerController)
    {
        if(!_playerController)
            _playerController = playerController;
        _playerController.CurrentSpeed = _playerController.runSpeed;
    }

    public void OnStateUpdate()
    {
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {
                if (_playerController.CurrentDirection == Direction.Right)
                {
                    _playerController.transform.Translate(
                    _playerController.CurrentSpeed * Time.deltaTime, 0, 0);
                }
                else if (_playerController.CurrentDirection == Direction.Left)
                {
                    _playerController.transform.Translate(
                    _playerController.CurrentSpeed * (-1) * Time.deltaTime, 0, 0);
                }
                else if (_playerController.CurrentDirection == Direction.Up)
                {
                    _playerController.transform.Translate(
                    0, _playerController.CurrentSpeed * Time.deltaTime, 0);
                }
                else if (_playerController.CurrentDirection == Direction.Down)
                {
                    _playerController.transform.Translate(
                    0, _playerController.CurrentSpeed * (-1) * Time.deltaTime, 0);
                }
            }
        }
    }

    public void OnStateExit()
    {

    }
}
