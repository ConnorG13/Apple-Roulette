using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public RoundEndState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Round End");

    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("END: Round End");
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        _stateMachine.ChangeState(_stateMachine.StartState);
        base.Tick();
    }
}
