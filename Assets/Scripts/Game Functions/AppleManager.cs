using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleManager : MonoBehaviour
{
    [SerializeField] private int _maxApples = 6;
    [SerializeField] private int _poisonApples = 1;
    private int _currentApple = 0;
    private int _poolLength;
    private int _poisonCount;
    private int[] _Apples;
    public bool _hasBiten = false;

    //private PlayerInfo _currentPlayer;
    private GameController _controller;

    void Start()
    {
        _controller = GameObject.FindObjectOfType<GameController>();
    }
    public void CreatePool()
    {
        //variables setting max apples + poison apples
        _poolLength = _maxApples;
        _poisonCount = _poisonApples;
        //create new pool of 6 apples
        _Apples = new int[_poolLength];

        //make the first apple poisoned
        for (int t = 0; t < _poisonCount; t++)
        {
            _Apples[t] = 1;
        }

        //every other apple is normal
        for (int t = _poisonCount; t < _Apples.Length; t++)
        {
            _Apples[t] = 0;
        }

        //shuffle
        for (int t = 0; t < _Apples.Length; t++)
        {
            int hold = _Apples[t];
            int r = Random.Range(t, _Apples.Length);
            _Apples[t] = _Apples[r];
            _Apples[r] = hold;
        }

    }
    public void ShufflePool()
    {
        //shuffle all apples that haven't been bitten yet (index X and onwards in array)
        for (int t = _currentApple; t < _Apples.Length; t++)
        {
            int hold = _Apples[t];
            int r = Random.Range(t, _Apples.Length);
            _Apples[t] = _Apples[r];
            _Apples[r] = hold;
        }
    }
    public void PullApple()
    {
        //_currentPlayer = _controller._currentPlayer.GetComponent<PlayerInfo>();
        //if the apple is safe...
        if (_Apples[_currentApple] == 0)
        {
            _controller._gameInfo.text = "That was a Safe Apple!";
        }
        else
        {
            _controller._gameInfo.text = "That was a Posioned Apple! OH NO";
            _controller._currentPlayer.hearts -= 1;
            
        }

        //move on to the next index value
        _currentApple++;
        //then check to see if there are any apples left
        _hasBiten = true;
    }
    public string SeeNextApple()
    {
        //effectively the same as pulling an apple...
        //but without moving to the next index
        if (_Apples[_currentApple] == 0)
        {
            return "This next apple is safe!";
        }
        else
        {
            return "This next apple is poisoned!";
        }
    }
    public bool CheckPoolFinished()
    {
        //if we're at the end of the index
        if (_currentApple >= _maxApples)
        {
            return true;
        } else
        {
            return false;
        }

    }
}
