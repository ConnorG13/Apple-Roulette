using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleVisualScript : MonoBehaviour
{

    public List <GameObject> appleVisuals = new List<GameObject>();
    public List <GameObject> wholeApples = new List<GameObject>();
    public List <(GameObject, Vector2)> fallingApples = new List<(GameObject, Vector2)>();
    public List <GameObject> waterApples = new List<GameObject>();
    private GameController _controller;
    private CapsuleCollider2D _appleBounds;
    private GameObject applesParent;
    private int appleNumber = 0;


    private bool areFalling;
    private bool doneFallingAnimation;


    private void Awake()
    {
        _controller = GameObject.FindObjectOfType<GameController>();
        _appleBounds = GameObject.Find("AppleBounds").GetComponent<CapsuleCollider2D>();
        applesParent = GameObject.Find("Apples");
    }

    Vector2 GetRandomPositionInAppleBounds()
    {
        Vector2 randomPosition = new Vector2(10000, 10000);
        while (!_appleBounds.OverlapPoint(randomPosition))
        {
            randomPosition = new Vector2(Random.Range(_appleBounds.bounds.min.x, _appleBounds.bounds.max.x), Random.Range(_appleBounds.bounds.min.y, _appleBounds.bounds.max.y));
        }
        return randomPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
    }




    // void Update() {
    //     if (areFalling)
    //     {
    //         areFalling = false;
    //         foreach ((GameObject fallingApple, Vector2 finalPos) in fallingApples)
    //         {
    //             if (fallingApple.transform.position.y <= finalPos.y)
    //             {
    //                 continue;
    //             }
    //             areFalling = true;
    //             fallingApple.transform.position = new Vector2(fallingApple.transform.position.x, fallingApple.transform.position.y - 0.1f);
    //         }
    //     } else if (!doneFallingAnimation)
    //     {
    //         // Remove whole apples and replace with bitten apples
    //         foreach ((GameObject obj, Vector2 pos) in fallingApples)
    //         {
    //             Destroy(obj);
    //         }

            

            
    //         doneFallingAnimation = true;
    //     }
    // }



    public void appleBite(int appID)
    {
        if (appID == 1)
        {
            AppleSpriteScript app = appleVisuals[appleVisuals.Count-1].GetComponent<AppleSpriteScript>();
            app.hasBitten = true;
            app.appleID = appID;
        }
        else if(appID == 2)
        {
            AppleSpriteScript app = appleVisuals[appleNumber].GetComponent<AppleSpriteScript>();
            appleNumber++;
            app.hasBitten = true;
            app.appleID = appID;
        }
        else if(appID == 3)
        {
            AppleSpriteScript app = appleVisuals[appleNumber].GetComponent<AppleSpriteScript>();
            appleNumber++;
            app.hasBitten = true;
            app.appleID = appID;
        }
    }

    public void spawnFallingApples(List<int> applesInBasin)
    {
        foreach(int apple in applesInBasin)
        {
            Vector2 randomPosition = GetRandomPositionInAppleBounds();
            GameObject obj = Instantiate(wholeApples[apple], randomPosition, Quaternion.identity, applesParent.transform);
            appleVisuals.Add(obj);
        }

    }

    public void refillPool(List<int> applesInBasin)
    {
        
        foreach(GameObject obj in appleVisuals)
        {
            AppleSpriteScript app = obj.GetComponent<AppleSpriteScript>();
            app.hasBitten = false;
        }
        
        // foreach(int apple in applesInBasin)
        // {
        //     Vector2 randomPosition = GetRandomPositionInAppleBounds();
        //     Vector2 fallingFromTop = new Vector2(randomPosition.x, 540);
        //     GameObject obj = Instantiate(wholeApples[apple], fallingFromTop, Quaternion.identity, applesParent.transform);
        //     fallingApples.Add((obj, fallingFromTop));
        // }

        appleNumber = 0;
 
    }
}
