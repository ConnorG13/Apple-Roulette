using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleManager : MonoBehaviour
{
    [SerializeField] private int _maxApples = 6;
    [SerializeField] private int _poisonApples = 1;

    public int _currentApple = 0;
    private int _poolLength;
    private int _poisonCount;
    private int[] _Apples;

    //for state machine purposes
    public bool _hasBiten = false;

    private GameController _controller;

    void Start()
    {
        _controller = GameObject.FindObjectOfType<GameController>();
    }

    public void CreatePool()
    {
        _poolLength = _maxApples;
        _poisonCount = _poisonApples;
        _Apples = new int[_poolLength];

        //poison
        for (int t = 0; t < _poisonCount; t++)
        {
            _Apples[t] = 1;
        }

        //normal
        for (int t = _poisonCount; t < _Apples.Length; t++)
        {
            _Apples[t] = 0;
        }

        //golden
        _Apples[_maxApples - 1] = 2;

        //randomize
        for (int t = 0; t < _Apples.Length; t++)
        {
            int hold = _Apples[t];
            int r = Random.Range(t, _Apples.Length);
            _Apples[t] = _Apples[r];
            _Apples[r] = hold;
        }

        _controller.appleVisuals.refillPool();

    }

    public void ShufflePool()
    {
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

        switch (_Apples[_currentApple])
        {
            //normal
            case 0:
                _controller._gameInfo.text = "Safe!";
                break;
            //poison
            case 1:
                _controller._gameInfo.text = "Uh oh! Poisoned!";
                _controller._currentPlayer.hearts -= 1;
                break;
            //gain money
            case 2:
                _controller._gameInfo.text = "Wow! Golden apple!";
                _controller._currentPlayer.coins += 3;
                break;
            //heal
            case 3:
                _controller._gameInfo.text = "Healthy!";
                if (_controller._currentPlayer.hearts < _controller._startingHearts)
                {
                    _controller._currentPlayer.hearts++;
                }
                break;
            //schrodinger
            case 4:
                _controller._gameInfo.text = "Weird, but tasty!";
                break;
        }

        _currentApple++;
        _hasBiten = true;
    }

    public string SeeNextApple()
    {

        if (_Apples[_currentApple] == 0)
        {
            return "This next apple is safe!";
        }
        else if (_Apples[_currentApple] == 4)
        {
            _Apples[_currentApple] = 1;
            return "This apple just went bad!";
        }
        else
        {
            return "This next apple is different!";
        }
    }

    public bool CheckPoolFinished()
    {
        if (_currentApple >= _maxApples)
        {
            return true;
        } else
        {
            return false;
        }

    }
}
