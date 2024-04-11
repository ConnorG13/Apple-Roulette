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
        _controller._PlayerTurnStatus.text = "Start the Next Round?";
        Debug.Log("STATE: Round End");
        _controller._NextRoundButton.SetActive(true);

    }

    public override void Exit()
    {
        base.Exit();
        _controller._TransitionToNextRound = false;
        _controller._NextRoundButton.SetActive(false);
        Debug.Log("END: Round End");
    }

    public override void FixedTick()
    {
        if (_controller._TransitionToNextRound)
        {
            _controller._appleManager._currentApple = 0;
            _stateMachine.ChangeState(_stateMachine.StartState);
        }

        base.FixedTick();
    }

    public override void Tick()
    { 
        base.Tick();
    }
}
