using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{

    public List<GameObject> _players =  new List<GameObject>();


    [Header("Sounds")]
    public AudioSource _playerWin;
    public AudioSource _roundStart;


    [Header("Starting Player Values")]
    public int _roundStartCoins;
    public int _startingHearts;

    [Header("Script Calls")]
    public AppleManager _appleManager;
    public PlayerInfo _currentPlayer;
    public AppleVisualScript appleVisuals;

    private int _playerTurn =  0;
    
    [Header("Text Mesh Pro")]
    public TextMeshProUGUI _gameInfo;
    public TextMeshProUGUI _PlayerTurnStatus;
    public TextMeshProUGUI _NextTurnText;

    [Header("Panels")]
    public GameObject _ShopObj;
    public GameObject _WinnerPanel;

    [Header("Buttons")]
    public Button biteButton;
    
    public GameObject _NextTurnButton;
    [HideInInspector]
    public bool _TransitionToNextTurn = false;

    public GameObject _NextRoundButton;
    [HideInInspector]
    public bool _TransitionToNextRound = false;



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
