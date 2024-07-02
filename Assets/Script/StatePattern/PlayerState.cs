using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerState : MonoBehaviour
{
    private PlayerController _playerController;
    private Vector2 movement;
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(_playerController != null)
        {
            /*_playerController.Idle();
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running(Direction.Right);
                else
                    _playerController.Walking(Direction.Right);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running(Direction.Left);
                else
                    _playerController.Walking(Direction.Left);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running(Direction.Up);
                else
                    _playerController.Walking(Direction.Up);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running(Direction.Down);
                else
                    _playerController.Walking(Direction.Down);
            }*/

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if(movement.x != 0 || movement.y != 0)
            {
                _playerController.Walking(movement);
            }
            else
            {
                _playerController.Idle();
            }

            _playerController._playerStateContext.UpdateState();
        }
        else
        {
            Debug.Log("null");
        }
        
    }       
}
