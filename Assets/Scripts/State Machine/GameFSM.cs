using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    //variables
    public GameSetupState SetupState { get; private set; }
    public PlayerMainState MainState { get; private set; }
    public PlayerTransitionState TransitionState { get; private set; }
    public RoundStartState StartState { get; private set; }
    public RoundEndState EndState { get; private set; }
    public BiteState BiteState { get; private set; }
    public ShopState ShopState { get; private set; }
    public WonState WonState { get; private set; }


    private void Awake()
    {
        _controller = GetComponent<GameController>();
        //instantiate
        SetupState = new GameSetupState(this, _controller);
        MainState = new PlayerMainState(this, _controller);
        TransitionState = new PlayerTransitionState(this, _controller);
        StartState = new RoundStartState(this, _controller);
        EndState = new RoundEndState(this, _controller);
        BiteState = new BiteState(this, _controller);
        ShopState = new ShopState(this, _controller);
        WonState = new WonState(this, _controller);
    }

    private void Start()
    {
        
        ChangeState(SetupState);
        
    }
}
