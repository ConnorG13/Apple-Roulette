using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleManager : MonoBehaviour
{
    [HideInInspector]
    public int _currentApple = 0;

    private int[] _Apples;
    private List<int> _applesInBasin = new List<int>();

    public enum gameModes {Standard, Golden, DoublePoison, Heal, GoldenHeal, Crazy};
    public gameModes myGameMode;

    public gameModes _parsedMode;

    public AudioSource _playerPoisoned;
    public AudioSource _playerDeath;
    public AudioSource _playerSafe;

    [HideInInspector]
    public bool _hasBiten = false;

    private GameController _controller;
    private ModeTracker _mode;

    void Start()
    {
        _controller = GameObject.FindObjectOfType<GameController>();
        _mode = GameObject.FindObjectOfType<ModeTracker>();

        _parsedMode = (gameModes)System.Enum.Parse(typeof(gameModes), _mode._modeName);

    }

    public void CreatePool()
    {
        _Apples = new int[6];

        switch (_parsedMode)
        {
            case gameModes.Standard:
                _Apples[0] = 1;
                _Apples[1] = 0;
                _Apples[2] = 0;
                _Apples[3] = 0;
                _Apples[4] = 0;
                _Apples[5] = 0;
                break;
            case gameModes.DoublePoison:
                _Apples[0] = 1;
                _Apples[1] = 1;
                _Apples[2] = 0;
                _Apples[3] = 0;
                _Apples[4] = 0;
                _Apples[5] = 0;
                break;
            case gameModes.Golden:
                _Apples[0] = 1;
                _Apples[1] = 2;
                _Apples[2] = 0;
                _Apples[3] = 0;
                _Apples[4] = 0;
                _Apples[5] = 0;
                break;
            case gameModes.Heal:
                _Apples[0] = 1;
                _Apples[1] = 3;
                _Apples[2] = 0;
                _Apples[3] = 0;
                _Apples[4] = 0;
                _Apples[5] = 0;
                break;
            case gameModes.GoldenHeal:
                _Apples[0] = 1;
                _Apples[1] = 2;
                _Apples[2] = 3;
                _Apples[3] = 0;
                _Apples[4] = 0;
                _Apples[5] = 0;
                break;
            case gameModes.Crazy:
                _Apples[0] = 1;
                _Apples[1] = 1;
                _Apples[2] = 2;
                _Apples[3] = 3;
                _Apples[4] = 0;
                _Apples[5] = 0;
                break;
        }

        //randomize
        for (int t = 0; t < _Apples.Length; t++)
        {
            int hold = _Apples[t];
            int r = Random.Range(t, _Apples.Length);
            _Apples[t] = _Apples[r];
            _Apples[r] = hold;
        }

        AddApplesInBasin(_Apples);

        _controller.appleVisuals.refillPool(_applesInBasin);
    }

    private void AddApplesInBasin(int[] apples) {
        for (int i = 0; i < apples.Length; i++) {
            _applesInBasin.Add(apples[i]);
        }
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
                _controller.appleVisuals.appleBite(2);
                _playerSafe.PlayDelayed(0.85f);
                break;
            //poison
            case 1:
                _controller._gameInfo.text = "Uh oh! Poisoned!";
                _controller._currentPlayer.hearts -= 1;
                _controller.appleVisuals.appleBite(1);
                if(_controller._currentPlayer.hearts == 0)
                {
                    _playerDeath.PlayDelayed(0.85f);
                }
                else
                _playerPoisoned.PlayDelayed(0.85f);
                break;
            //golden
            case 2:
                _controller._gameInfo.text = "Wow! Golden apple!";
                _controller._currentPlayer.coins += 3;
                _controller.appleVisuals.appleBite(3);
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
        if (_currentApple >= 6)
        {
            return true;
        } else
        {
            return false;
        }

    }
}
