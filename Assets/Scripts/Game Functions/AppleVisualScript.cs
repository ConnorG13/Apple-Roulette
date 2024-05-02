using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleVisualScript : MonoBehaviour
{

    public List<GameObject> appleVisuals = new List<GameObject>();
    [SerializeField] public GameObject GoodWholeApple;
    [SerializeField] public GameObject BadWholeApple;
    [SerializeField] public GameObject GoodWaterApple;
    [SerializeField] public GameObject BadWaterApple;
    [SerializeField] public GameObject WaterSplash;
    [SerializeField] public AudioSource SplashAudio;

    public List<(GameObject, Vector2)> fallingApples = new List<(GameObject, Vector2)>();
    private GameController _controller;
    private CapsuleCollider2D _appleBounds;
    private GameObject applesParent;
    private int appleNumber = 0;

    [SerializeField]
    private float _fallingSpeed = 100.0f;

    private bool areFalling;
    private bool doneFallingAnimation;
    private bool doneSplashAnimation;
    private int[] _Apples;
    private List<Vector2> positions;
    private int applesInBasin = 0;


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

    private void disableEventSystem()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().enabled = false;
    }

    private void enableEventStstem()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().enabled = true;
    }

    private GameObject decideWaterApple(int appleID)
    {
        if (isBadApple(appleID))
        {
            return BadWaterApple;
        }
        else
        {
            return GoodWaterApple;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    List<Vector2> getRandomYOrderedApplePositions(int count)
    {
        List<Vector2> yOrderedApplePositions = new List<Vector2>();
        for (int i = 0; i < count; i++)
        {
            Vector2 randomPosition = GetRandomPositionInAppleBounds();
            yOrderedApplePositions.Add(randomPosition);
        }
        yOrderedApplePositions.Sort((a, b) => a.y.CompareTo(b.y));
        return yOrderedApplePositions;
    }

    void Update()
    {
        if (areFalling)
        {
            areFalling = false;
            foreach ((GameObject fallingApple, Vector2 finalPos) in fallingApples)
            {
                if (fallingApple.transform.position.y <= finalPos.y)
                {
                    continue;
                }
                areFalling = true;
                if (Time.deltaTime > 0.5f)
                    Time.timeScale = 0.5f;
                fallingApple.transform.position = new Vector2(fallingApple.transform.position.x, fallingApple.transform.position.y - _fallingSpeed * Time.deltaTime);
            }
        }
        else if (!doneFallingAnimation)
        {
            doneFallingAnimation = true;
            positions = new List<Vector2>();
            // Remove whole apples and replace with bitten apples
            foreach ((GameObject obj, Vector2 pos) in fallingApples)
            {
                positions.Add(pos);
                Destroy(obj);
            }

            StartCoroutine(PlayWaterSplash());
        }
        else if (doneSplashAnimation)
        {
            WaterSplash.SetActive(false);

            List<Vector2> yOrderedApplePositions = getRandomYOrderedApplePositions(6);
            yOrderedApplePositions.Reverse();

            // add water apples

            for (int i = 0; i < yOrderedApplePositions.Count; i++)
            {
                if (applesInBasin >= 6)
                {
                    break;
                }
                applesInBasin++;
                int apple = _Apples[i];
                GameObject obj = Instantiate(decideWaterApple(apple), yOrderedApplePositions[i], Quaternion.identity, applesParent.transform);
                obj.tag = isBadApple(apple) ? "bad" : "good";
            }

            enableEventStstem();
        }
    }

    IEnumerator PlayWaterSplash()
    {
        WaterSplash.SetActive(true);
        SplashAudio.Play(1);
        yield return new WaitForSeconds(2.0f);
        doneSplashAnimation = true;
    }


    public void appleBite(int appID)
    {
        if (appID == 1)
        {
            AppleSpriteScript app = appleVisuals[appleNumber].GetComponent<AppleSpriteScript>();
            app.hasBitten = true;
            appleNumber++;
            app.appleID = appID;
        }
        else if (appID == 2)
        {
            AppleSpriteScript app = appleVisuals[appleNumber].GetComponent<AppleSpriteScript>();
            appleNumber++;
            app.hasBitten = true;
            app.appleID = appID;
        }
        else if (appID == 3)
        {
            AppleSpriteScript app = appleVisuals[appleNumber].GetComponent<AppleSpriteScript>();
            appleNumber++;
            app.hasBitten = true;
            app.appleID = appID;
        }

        // remove from basin
        if (isBadApple(appID))
        {
            Destroy(GameObject.FindWithTag("bad"));
        }
        else
        {
            Destroy(GameObject.FindWithTag("good"));
        }
    }

    bool isBadApple(int appleID)
    {
        return appleID == 1;
    }

    GameObject decideWholeApple(int appleID)
    {
        if (isBadApple(appleID))
        {
            return BadWholeApple;
        }
        else
        {
            return GoodWholeApple;
        }
    }

    public void spawnFallingApples(int[] Apples)
    {
        areFalling = true;
        doneFallingAnimation = false;
        doneSplashAnimation = false;
        disableEventSystem();
        fallingApples.Clear();
        applesInBasin = 0;
        foreach (int apple in Apples)
        {
            Debug.Log(apple);
            Vector2 randomPosition = GetRandomPositionInAppleBounds();
            int randomNoiseY = Random.Range(-50, 50);
            Vector2 topPosition = new Vector2(randomPosition.x, 1300 + randomNoiseY);
            GameObject obj = Instantiate(decideWholeApple(apple), topPosition, Quaternion.identity, applesParent.transform);
            fallingApples.Add((obj, randomPosition));
        }

    }

    public void refillPool(int[] Apples)
    {
        _Apples = Apples;

        WaterSplash.SetActive(false);
        foreach (GameObject obj in appleVisuals)
        {
            AppleSpriteScript app = obj.GetComponent<AppleSpriteScript>();
            app.isBad = false;
            app.appleID = 0;
            app.hasBitten = false;
        }

        spawnFallingApples(Apples);

        appleNumber = 0;

    }
}
