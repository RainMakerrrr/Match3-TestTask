using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer Sprite;

    public bool IsSelected { get; set; }

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }
}
