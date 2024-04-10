using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransitionState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public PlayerTransitionState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Player Transition");

    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("END: Player Transition");
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }
}
