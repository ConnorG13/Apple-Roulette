using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfo : MonoBehaviour
{

    public int coins;
    public int hearts;
    public string name;
    public TextMeshProUGUI heartsText;
    public TextMeshProUGUI coinsText;
    private GameController gameController;
    public GameObject skull;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();

        
    }
    private void Start()
    {
        coins = gameController._roundStartCoins;
        hearts = gameController._startingHearts;
        skull.SetActive(false);
    }

    // Update is called once per frame
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
