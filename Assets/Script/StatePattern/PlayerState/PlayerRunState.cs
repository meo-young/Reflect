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
                /*if (_playerController.CurrentDirection == Direction.Right)
                {
                    Running(Direction.Right);
                }
                else if (_playerController.CurrentDirection == Direction.Left)
                {
                    Running(Direction.Left);
                }
                else if (_playerController.CurrentDirection == Direction.Up)
                {
                    Running(Direction.Up);
                }
                else if (_playerController.CurrentDirection == Direction.Down)
                {
                    Running(Direction.Down);
                }*/
            }
        }
    }

    public void OnStateExit()
    {

    }

    private void Running(Direction _direction)
    {
        int _dirX = 0;
        int _dirY = 0;

        if (_direction == Direction.Right)
        {
            _dirX = 1;
            _dirY = 0;
        }
        else if (_direction == Direction.Left)
        {
            _dirX = -1;
            _dirY = 0;
        }
        else if (_direction == Direction.Up)
        {
            _dirX = 0;
            _dirY = 1;
        }
        else if (_direction == Direction.Down)
        {
            _dirX = 0;
            _dirY = -1;
        }
        _playerController.transform.Translate(_playerController.CurrentSpeed * Time.deltaTime * _dirX, _playerController.CurrentSpeed * Time.deltaTime * _dirY, 0);
        /*anim.SetFloat("DirX", _dirX);
        anim.SetFloat("DirY", _dirY);*/
    }
}
