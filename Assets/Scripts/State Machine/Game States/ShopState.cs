using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public ShopState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Shop");

    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("END: Shop");
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
