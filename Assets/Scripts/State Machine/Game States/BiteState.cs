using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public BiteState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("STATE: Bite");
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("END: Bite");
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        _controller._appleManager.PullApple();
        _stateMachine.ChangeState(_stateMachine.TransitionState);
        base.Tick();
    }
}
