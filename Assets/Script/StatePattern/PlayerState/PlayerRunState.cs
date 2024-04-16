using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    public void Handle(PlayerController playerController)
    {
        if(!_playerController)
            _playerController = playerController;
        _playerController.CurrentSpeed = _playerController.runSpeed;
    }

    void Update()
    {
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {
                _playerController.transform.Translate(
                   _playerController.runSpeed * Time.deltaTime,0,0);
            }
        }
    }
}
