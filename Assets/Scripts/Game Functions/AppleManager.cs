using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    private int _poolLength;
    private int _poisonCount;
    private int[] _Apples;
    
    void Start()
    {

        CreatePool();
    }

    public void CreatePool()
    {
        _poolLength = Mathf.RoundToInt(Random.Range(4f, 8f));
        _poisonCount = Mathf.RoundToInt(Random.Range(1f, (_poolLength - 2)));
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
}
