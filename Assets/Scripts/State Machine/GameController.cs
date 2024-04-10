using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{

    public GameObject _player1;
    public GameObject _player2;
    public GameObject _player3;
    public GameObject _player4;
    public AppleManager _appleManager;
    public GameObject _currentPlayer;
    public TextMeshProUGUI _gameInfo;

    public int _roundStartCoins;
    public int _startingHearts;
    //[Header("Game Data")]
    //[SerializeField] private float _tapLimitDuration = 2.5f;

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
