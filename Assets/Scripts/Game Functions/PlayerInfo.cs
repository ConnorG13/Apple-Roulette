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
    private GameController gameController;
    public GameObject skull;
    public bool isAlive = true;

    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();  
    }

    private void Start()
    {
        coins = 0;
        hearts = gameController._startingHearts;
        skull.SetActive(false);
    }

    void Update()
    {
        heartsText.text = ":" + hearts.ToString();
        coinsText.text = ":" + coins.ToString();

        if(hearts <= 0)
        {
            isAlive = false;
            skull.SetActive(true);
        }
    }
}
