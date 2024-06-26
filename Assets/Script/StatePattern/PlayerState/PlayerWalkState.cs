using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerWalkState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private Animator anim;
    private int wallLayer; // 벽 Layer 설정 변수

    public void OnStateEnter(PlayerController playerController)
    {
        if(!_playerController)
            _playerController = playerController;
        _playerController.CurrentSpeed = _playerController.Speed;
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", true);

        // "Wall" Layer의 인덱스를 가져옴
        wallLayer = LayerMask.NameToLayer("Wall");
    }


    public void OnStateUpdate()
    {
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {
                if(_playerController.CurrentDirection == Direction.Right)
                {
                    if (!IsCollidingWithWall(UnityEngine.Vector2.right))
                        Walking(Direction.Right);
                }
                else if (_playerController.CurrentDirection == Direction.Left)
                {
                    if (!IsCollidingWithWall(UnityEngine.Vector2.left))
                        Walking(Direction.Left);
                }
                else if (_playerController.CurrentDirection == Direction.Up)
                {
                    if (!IsCollidingWithWall(UnityEngine.Vector2.up))
                        Walking(Direction.Up);
                }
                else if(_playerController.CurrentDirection == Direction.Down)
                {
                    if (!IsCollidingWithWall(UnityEngine.Vector2.down))
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

    private bool IsCollidingWithWall(UnityEngine.Vector2 direction)
    {
        float distance = 0.1f; // Raycast 거리
        RaycastHit2D hit = Physics2D.Raycast(_playerController.transform.position, direction, distance, 1 << wallLayer);

        if (hit.collider != null)
        {
            anim.SetBool("Walking", false);
            return true;
        }
        else
        {
            anim.SetBool("Walking", true);
            return false;
        }
    }

}
