using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    [SerializeField] private int _maxApples = 6;
    [SerializeField] private int _poisonApples = 1;
    private int _currentApple = 0;
    private int _poolLength;
    private int _poisonCount;
    private int[] _Apples;
    
    void Start()
    {
        CreatePool();
    }
    public void CreatePool()
    {
        _poolLength = _maxApples;
        _poisonCount = _poisonApples;
        _Apples = new int[_poolLength];

        for (int t = 0; t < _poisonCount; t++)
        {
            _Apples[t] = 1;
        }

        for (int t = _poisonCount; t < _Apples.Length; t++)
        {
            _Apples[t] = 0;
        }


        for (int t = 0; t < _Apples.Length; t++)
        {
            int hold = _Apples[t];
            int r = Random.Range(t, _Apples.Length);
            _Apples[t] = _Apples[r];
            _Apples[r] = hold;
        }


        foreach (int t in _Apples)
        {
            Debug.Log(t.ToString());
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
        if (_Apples[_currentApple] == 0)
        {
            //0 = safe
        }
        else
        {
            //1 = poison
        }

        _currentApple++;
    }
}
