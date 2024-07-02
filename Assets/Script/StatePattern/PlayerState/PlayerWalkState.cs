using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private Animator anim;
    private Rigidbody2D rb;

    public void OnStateEnter(PlayerController playerController)
    {
        if(!_playerController)
            _playerController = playerController;
        _playerController.CurrentSpeed = _playerController.Speed;
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", true);

        rb = GetComponent<Rigidbody2D>();
    }


    public void OnStateUpdate()
    {
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {

                Walking(_playerController.CurrentDirection);
            }
        }
    }
    public void OnStateExit()
    {
        anim.SetBool("Walking", false);
    }

    private void Walking(Vector2 _direction)
    {
        rb.MovePosition(rb.position + _playerController.CurrentDirection * _playerController.CurrentSpeed * Time.fixedDeltaTime);

        _playerController.CurrentSpeed = _playerController.Speed;
        anim.SetFloat("DirX", _direction.x);
        anim.SetFloat("DirY", _direction.y);
    }



}
