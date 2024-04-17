using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerState : MonoBehaviour
{
    private PlayerController _playerController;
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(_playerController != null)
        {
            _playerController.Idle();
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running();
                else
                    _playerController.Walking(Direction.Right);
                Debug.Log("hi");
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running();
                else
                    _playerController.Walking(Direction.Left);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running();
                else
                    _playerController.Walking(Direction.Up);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    _playerController.Running();
                else
                    _playerController.Walking(Direction.Down);
            }
            _playerController._playerStateContext.UpdateState();
        }
        else
        {
            Debug.Log("null");
        }
        
    }       
}
