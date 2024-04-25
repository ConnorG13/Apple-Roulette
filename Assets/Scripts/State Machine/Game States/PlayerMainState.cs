using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerMainState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public PlayerMainState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller._PlayerTurnStatus.text = _controller._currentPlayer.name + "'s Turn";
        _controller._gameInfo.text = "Open the shop and spend coins or Bite into the Apple.";
        _controller.biteButton.enabled = true;
        Debug.Log("STATE: Player Main");

    }

    public override void Exit()
    {
        base.Exit();
        _controller.biteButton.enabled = false;
        _controller._ShopObj.SetActive(false);
        Debug.Log("END: Player Main");
    }

    public override void FixedTick()
    {
        base.FixedTick();
        if (_controller._appleManager._hasBiten)
        {
            _controller._appleManager._hasBiten = false;
            _stateMachine.ChangeState(_stateMachine.TransitionState);
        }
    }

    public override void Tick()
    {
        base.Tick();
    }
}
