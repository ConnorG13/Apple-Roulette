using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeTracker : MonoBehaviour
{
    public string _modeName = "DoublePoison";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
