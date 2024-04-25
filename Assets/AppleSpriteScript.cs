using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleSpriteScript : MonoBehaviour
{
    public Sprite appleOutline;
    public Sprite appleGood;
    public Sprite appleBad;
    public Sprite appleGolden;
    public bool hasBitten;
    public bool isBad;
    private Image appleImage;


    private void Awake()
    {
        appleImage = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        if (isBad)
        {
            appleImage.sprite = appleBad;
        }
        else
        {
            appleImage.sprite = appleGood;
        }
    }

    private void FixedUpdate()
    {
        if (hasBitten)
        {
            appleImage.sprite = appleOutline;
        }
        else if (isBad)
        {
            appleImage.sprite = appleBad;
        }
        else
        {
            appleImage.sprite = appleGood;
        }
    }
}
