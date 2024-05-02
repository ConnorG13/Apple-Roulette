using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public RoundStartState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("STATE: Round Start");
        _controller._roundStart.Play();
        
        foreach(GameObject obj in _controller._players)
        {
            obj.GetComponent<PlayerInfo>().coins += _controller._roundStartCoins;
        }
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("END: Round Start");
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        _controller._appleManager.CreatePool();
        _stateMachine.ChangeState(_stateMachine.MainState);
        base.Tick();
    }
}
