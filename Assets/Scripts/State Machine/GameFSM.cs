using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    //variables
    public GameSetupState SetupState { get; private set; }
    //public GamePlayState PlayState { get; private set; }
    

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        //instantiate
        SetupState = new GameSetupState(this, _controller);
        //PlayState = new GamePlayState(this, _controller);
    }

    private void Start()
    {
        /*
        ChangeState(SetupState);
        */
    }
}
