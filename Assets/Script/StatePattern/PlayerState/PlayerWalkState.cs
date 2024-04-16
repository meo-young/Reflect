using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    public void Handle(PlayerController playerController)
    {
        if(!_playerController)
            _playerController = playerController;
        _playerController.CurrentSpeed = _playerController.Speed;
    }

    void Update()
    {
        if (_playerController)
        {
            if(_playerController.CurrentSpeed > 0)
            {
                _playerController.transform.Translate(
                    _playerController.Speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
