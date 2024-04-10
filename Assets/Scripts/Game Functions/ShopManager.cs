using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameController _gameController;
    private PlayerInfo _playerInfo;
    public AppleManager _appleManager;
    public int ShuffleCost;
    public int CheckCost;
    public int SkipCost;
    
    void Start()
    {
        
    }

    public void AppleShuffle()
    {
        _playerInfo = _gameController._currentPlayer.GetComponent<PlayerInfo>();
        if (_playerInfo.coins >= ShuffleCost)
        {
            _playerInfo.coins -= ShuffleCost;
            _appleManager.ShufflePool();
        }
        else
        {
            Debug.Log("not enough coins for shuffle");
        }
    }
    public void AppleCheck()
    {
        _playerInfo = _gameController._currentPlayer.GetComponent<PlayerInfo>();
        if (_playerInfo.coins >= CheckCost)
        {
            _playerInfo.coins -= CheckCost;
            string appleStatus = _appleManager.SeeNextApple();
        }
        else
        {
            Debug.Log("not enough coins for check");
        }
    }
    void Update()
    {
        
    }
}
