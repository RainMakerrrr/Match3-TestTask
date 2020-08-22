using UnityEngine;

public class Board : MonoBehaviour
{
    public BoardSettings BoardSettings;
    public static Board Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Tile[,] CreateBoard()
    {
        Tile[,] tiles = new Tile[BoardSettings.xSize,BoardSettings.ySize];

        float posX = transform.position.x;
        float posY = transform.position.y;

        Vector2 tileSize = BoardSettings.Tile.Sprite.bounds.size;

        for(int x = 0; x < BoardSettings.xSize; x++)
        {
            for (int y = 0; y < BoardSettings.ySize; y++)
            {
               
                var newTile = Instantiate(BoardSettings.Tile, transform.position, Quaternion.identity);
                newTile.transform.position = new Vector3(posX + (tileSize.x * x), posY + (tileSize.y * y), 0f);
                newTile.transform.parent = transform;

                tiles[x, y] = newTile;

                Sprite randomSprite = BoardSettings.Sprites[Random.Range(0,BoardSettings.Sprites.Count)];
                newTile.Sprite.sprite = randomSprite;
                BoardSettings.Sprites.Remove(randomSprite);                              
            }
        }
        return tiles;
    }

}