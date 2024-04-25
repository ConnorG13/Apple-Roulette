using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleVisualScript : MonoBehaviour
{

    public List <GameObject> appleVisuals = new List<GameObject>();
    private GameController _controller;
    private int appleNumber = 0;


    private void Awake()
    {
        _controller = GameObject.FindObjectOfType<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            app.appleID = appID;
        }
    }

    public void refillPool()
    {
        foreach(GameObject obj in appleVisuals)
        {
            AppleSpriteScript app = obj.GetComponent<AppleSpriteScript>();
            app.hasBitten = false;
        }

        appleNumber = 0;
 
    }
}
