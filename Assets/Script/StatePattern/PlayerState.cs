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
            if(movement.x == 0)
            {
                movement.y = Input.GetAxisRaw("Vertical");
            }
            if(movement.y == 0)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
            }
           
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
