using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WonState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public WonState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller._playerWin.Play();
        _controller._WinnerPanel.SetActive(true);
        Debug.Log("STATE: Won");

    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("END: Won");
    }

    public override void FixedTick()
    {
        if (StateDuration > 6)
        {
            SceneManager.LoadScene("MainMenu");
        }
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }
}
