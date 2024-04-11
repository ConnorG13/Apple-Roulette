using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{

    public List<GameObject> _players =  new List<GameObject>();

    public AppleManager _appleManager;
    public PlayerInfo _currentPlayer;
    private int _playerTurn =  0;
    public TextMeshProUGUI _gameInfo;

    public int _roundStartCoins;
    public int _startingHearts;

    public Button biteButton;
    public GameObject _ShopObj;
    public TextMeshProUGUI _PlayerTurnStatus;

    public GameObject _NextTurnButton;
    public bool _TransitionToNextTurn = false;

    public GameObject _NextRoundButton;
    public bool _TransitionToNextRound = false;

    public GameObject _WinnerPanel;

    private void Start()
    {
        _currentPlayer = _players[_playerTurn].GetComponent<PlayerInfo>();
    }
    public void switchPlayerTurn()
    {
        _playerTurn += 1;
        if(_playerTurn > _players.Count-1)
        {
            _playerTurn = 0;
        }
        _currentPlayer = _players[_playerTurn].GetComponent<PlayerInfo>();

    }

    public void killPlayer()
    {
        Debug.Log("Killing Player");
        _players.RemoveAt(_playerTurn);
        _playerTurn -= 1;
        switchPlayerTurn();
    }

    public void NextTurnPressed()
    {
        _TransitionToNextTurn = true;
    }
    public void NextRoundPressed()
    {
        _TransitionToNextRound = true;
    }

}
