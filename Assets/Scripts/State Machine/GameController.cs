using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameObject biteButton;
    public GameObject ShopObj;


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


    }

    public void killPlayer()
    {
        Debug.Log("Killing Player");
        _players.RemoveAt(_playerTurn);
        _playerTurn -= 1;
    }
    /*
    [Header("Dependencies")]
    [SerializeField] private AppleManager _appleManager;

    public AppleManager AppleManager => _appleManager;


    [SerializeField] private Unit _playerUnitPrefab;
    [SerializeField] private Transform _playerUnitSpawn;
    [SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private InputBroadcaster _input;
    [SerializeField] private GameHUD _HUD;
    [SerializeField] private ActionCounter _AC;
    [SerializeField] private TurnCounter _TC;
    [SerializeField] private AudioSource _audio;

    public float TapLimitDuration => _tapLimitDuration;
    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawn => _playerUnitSpawn;
    public UnitSpawner UnitSpawner => _unitSpawner;
    public InputBroadcaster Input => _input;
    public GameHUD HUD => _HUD;
    public ActionCounter ActionCounter => _AC;
    public TurnCounter TurnCounter => _TC;
    public AudioSource AudioSource => _audio;
    */

}
