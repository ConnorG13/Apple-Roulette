using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeTracker : MonoBehaviour
{
    public string _modeName = "Standard";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeMode(string _nameOfMode)
    {
        _modeName = _nameOfMode;
    }
}
