using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIAnimation : MonoBehaviour
{
    public float duration;

    [SerializeField] private Sprite[] sprites;

    private Image image;
    private int index = 0;
    private float timer = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (duration <= 0 || sprites.Length == 0) return;

        if (timer >= duration/sprites.Length)
        {
            timer = 0;
            index %= sprites.Length;
            image.sprite = sprites[index++];
        }
    }
}
