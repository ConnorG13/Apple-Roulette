using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public AudioSource _playerBuy;
    public AudioSource _playerInvalid;
    private GameController _controller;
    private PlayerInfo _playerInfo;
    public AppleManager _appleManager;
    public int ShuffleCost;
    public int CheckCost;
    public int SkipCost;
    
    void Start()
    {
       _controller = GameObject.FindObjectOfType<GameController>();
    }

    public void AppleShuffle()
    {
        _playerInfo = _controller._currentPlayer.GetComponent<PlayerInfo>();
        if (_playerInfo.coins >= ShuffleCost)
        {
            _playerInfo.coins -= ShuffleCost;
            _appleManager.ShufflePool();
            _controller._gameInfo.text = "You Shuffled Up the Apple Pool";

            _playerBuy.PlayDelayed(0.12f);
        }
        else
        {
            _playerInvalid.PlayDelayed(0.12f);
            _controller._gameInfo.text = "Not enough coins for the Shuffle Powerup";
        }
    }
    public void AppleCheck()
    {
        _playerInfo = _controller._currentPlayer.GetComponent<PlayerInfo>();
        if (_playerInfo.coins >= CheckCost)
        {
            _playerInfo.coins -= CheckCost;
            string appleStatus = _appleManager.SeeNextApple();
            _controller._gameInfo.text = appleStatus;
            
            _playerBuy.PlayDelayed(0.12f);
        }
        else
        {
            _playerInvalid.PlayDelayed(0.12f);
            _controller._gameInfo.text = "Not enough coins for the Check Powerup";
        }
    }

    public void SkipTurn()
    {
        
        _playerInfo = _controller._currentPlayer.GetComponent<PlayerInfo>();
        if (_playerInfo.coins >= SkipCost)
        {
            _playerInfo.coins -= SkipCost;
            _appleManager._hasBiten = true;
            _controller._ShopObj.SetActive(false);
            
            _playerBuy.PlayDelayed(0.12f);
        }
        else
        {
            _playerInvalid.PlayDelayed(0.12f);
            _controller._gameInfo.text = "Not enough coins for the Skip Powerup";
        }
    }
    void Update()
    {
        
    }
}
