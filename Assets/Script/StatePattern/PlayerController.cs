using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 2.0f;
    public float Speed = 1.0f;
    public float CurrentSpeed
    {
        get; set;
    }

    public Direction CurrentDirection
    {
        get; private set;
    }

    private IPlayerState _idleState, _walkState, _runState;

    private PlayerStateContext _playerStateContext;

    private void Start()
    {
        _playerStateContext = new PlayerStateContext(this);

        _idleState = gameObject.AddComponent<PlayerIdleState>();
        _walkState = gameObject.AddComponent<PlayerWalkState>();
        _runState = gameObject.AddComponent<PlayerRunState>();

        _playerStateContext.Transition(_idleState);
    }

    public void Walking(Direction direction)
    {
        CurrentDirection = direction;
        _playerStateContext.Transition(_walkState);
    }
    public void Running()
    {
        _playerStateContext.Transition(_runState);
    }
    public void Idle()
    {
        _playerStateContext.Transition(_idleState);
    }
}
