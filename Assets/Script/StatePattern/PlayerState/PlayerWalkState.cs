using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerWalkState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private Animator anim;

    public void OnStateEnter(PlayerController playerController)
    {
        if(!_playerController)
            _playerController = playerController;
        _playerController.CurrentSpeed = _playerController.Speed;
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", true);
    }


    public void OnStateUpdate()
    {
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {
                if(_playerController.CurrentDirection == Direction.Right)
                {
                    Walking(Direction.Right);
                }
                else if (_playerController.CurrentDirection == Direction.Left)
                {
                    Walking(Direction.Left);
                }
                else if (_playerController.CurrentDirection == Direction.Up)
                {
                    Walking(Direction.Up);
                }
                else if(_playerController.CurrentDirection == Direction.Down)
                {
                    Walking(Direction.Down);
                }
            }
        }
    }
    public void OnStateExit()
    {
        anim.SetBool("Walking", false);
    }

    private void Walking(Direction _direction)
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
        anim.SetFloat("DirX", _dirX);
        anim.SetFloat("DirY", _dirY);
    }
}
