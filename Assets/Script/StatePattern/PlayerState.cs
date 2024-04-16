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
                _playerController.Walking(Direction.Right);
            if (Input.GetKey(KeyCode.LeftArrow))
                _playerController.Walking(Direction.Left);
            if (Input.GetKey(KeyCode.UpArrow))
                _playerController.Walking(Direction.Up);
            if (Input.GetKey(KeyCode.DownArrow))
                _playerController.Walking(Direction.Down);
        }
        else
        {
            Debug.Log("null");
        }
        
    }       
}
