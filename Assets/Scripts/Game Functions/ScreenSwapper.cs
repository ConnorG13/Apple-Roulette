using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwapper : MonoBehaviour
{
    private GameObject _title;
    private GameObject _mainScreen;
    private GameObject _modeScreen;
    private GameObject _rulesScreen;

    private void Awake()
    {
       _title = this.gameObject.transform.GetChild(1).gameObject;
       _mainScreen = this.gameObject.transform.GetChild(2).gameObject;
       _modeScreen = this.gameObject.transform.GetChild(3).gameObject;
       _rulesScreen = this.gameObject.transform.GetChild(4).gameObject;
    }

    public void SwapToScreen(int _screenNum)
    {
        switch (_screenNum)
        {
            case 2:
                _title.SetActive(true);
                _mainScreen.SetActive(true);
                _modeScreen.SetActive(false);
                _rulesScreen.SetActive(false);
                break;
            case 3:
                _title.SetActive(false);
                _mainScreen.SetActive(false);
                _modeScreen.SetActive(true);
                _rulesScreen.SetActive(false);
                break;
            case 4:
                _title.SetActive(false);
                _mainScreen.SetActive(false);
                _modeScreen.SetActive(false);
                _rulesScreen.SetActive(true);
                break;
        }
    }
}
