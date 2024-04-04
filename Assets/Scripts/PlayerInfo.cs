using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfo : MonoBehaviour
{

    public int coins;
    public int hearts;
    public TextMeshProUGUI heartsText;
    public TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {

        heartsText.text = ":" + hearts.ToString();
        coinsText.text = ":" + coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
