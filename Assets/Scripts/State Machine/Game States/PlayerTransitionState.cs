using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        Debug.Log("STATE: Transition State");
        if (_controller._currentPlayer.hearts <= 0)
        {
            _controller.killPlayer();
            Debug.Log("kill player");
        }
        else
        {
            _controller.switchPlayerTurn();
            Debug.Log("swap player in states");
        }

        _controller._NextTurnText.text = "Pass the Phone to " + _controller._currentPlayer.name;

        _controller._NextTurnButton.SetActive(true);


    }

    public override void Exit()
    {
        base.Exit();
        _controller._NextTurnButton.SetActive(false);
        _controller._TransitionToNextTurn = false;
        Debug.Log("END: Player Transition");
    }

    public override void FixedTick()
    {

        if (_controller._TransitionToNextTurn)
        {
            if (_controller._players.Count == 1)
            {
                _stateMachine.ChangeState(_stateMachine.WonState);
            }else if (_controller._appleManager.CheckPoolFinished())
            {
                _stateMachine.ChangeState(_stateMachine.EndState);
            } else
            {
                _stateMachine.ChangeState(_stateMachine.MainState);
            }
        }
        
    }

    public override void Tick()
    {
        base.Tick();
    }
}
