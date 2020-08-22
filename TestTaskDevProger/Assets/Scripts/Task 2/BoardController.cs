using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    
    private Tile[,] _tiles;
    private Tile _oldSelectedTile;

    private Vector2[] _rayDirection = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    private bool _isFindMatch;

    private void Start()
    {
        _tiles = Board.Instance.CreateBoard();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if(hit.point != null)
            {
                CheckForSelectingTile(hit.collider.GetComponent<Tile>());
            }
        }
    }

    private void SelectTile(Tile tile)
    {
        tile.IsSelected = true;
        tile.Sprite.color = new Color(0.5f, 0.5f, 0.5f);
        _oldSelectedTile = tile;
    }

    private void DeselectTile(Tile tile)
    {
        tile.IsSelected = false;
        tile.Sprite.color = new Color(1f, 1f, 1f);
        _oldSelectedTile = null;
    }
    
    private void CheckForSelectingTile(Tile tile)
    { 
        if (tile.IsSelected) DeselectTile(tile);
        else
        {
            if (!tile.IsSelected && _oldSelectedTile == null) SelectTile(tile);

            else if (NeighboringTiles().Contains(tile))
            {
                SwapTiles(tile);
                FindAllMatches(tile);
                DeselectTile(_oldSelectedTile);
            }
            else
            {
                DeselectTile(_oldSelectedTile);
                SelectTile(tile);  
            }
        }
    }

    private void SwapTiles(Tile tile)
    {
        if (_oldSelectedTile.Sprite.sprite.name == "no-Move") return;
        if (_oldSelectedTile.Sprite.sprite.name == "Player" && tile.Sprite.sprite.name == "MatchBox" || tile.Sprite.sprite.name =="no-Move") return;
        if (_oldSelectedTile.Sprite.sprite.name == "MatchBox" && tile.Sprite.sprite.name == "Player" || tile.Sprite.sprite.name == "no-Move") return;

        if (_oldSelectedTile.Sprite.sprite.name == "Player" && tile.Sprite.sprite.name == "Exit")
        {
            _winPanel.SetActive(true);
            StartCoroutine(PassLevel());
            return;
        }

        Sprite cashSprite = _oldSelectedTile.Sprite.sprite;
        _oldSelectedTile.Sprite.sprite = tile.Sprite.sprite;
        tile.Sprite.sprite = cashSprite;
    }

    private IEnumerator PassLevel()
    {
        LevelManager.Instance.PassLevel();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(4);
    }

    private List<Tile> NeighboringTiles()
    {
        List<Tile> neighboringTiles = new List<Tile>();

        for(int i = 0; i < _rayDirection.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(_oldSelectedTile.transform.position, _rayDirection[i]);
            if (hit.collider != null)
                neighboringTiles.Add(hit.collider.GetComponent<Tile>());
        }
        return neighboringTiles;
    }

    private List<Tile> FindMatch(Tile tile, Vector2 direction)
    {
        List<Tile> cashFindedMatches = new List<Tile>();
        RaycastHit2D hit = Physics2D.Raycast(tile.transform.position, direction);

        while(hit.collider != null && hit.collider.GetComponent<Tile>().Sprite.sprite.name == "MatchBox" && tile.Sprite.sprite.name == "MatchBox")
        {
            cashFindedMatches.Add(hit.collider.GetComponent<Tile>());
            hit = Physics2D.Raycast(hit.transform.position, direction);
        }

        return cashFindedMatches;
    }

    private void ReplaceTile(Tile tile, Vector2[] directions)
    {
        List<Tile> cashFindedMatches = new List<Tile>();

        for(int i = 0; i < directions.Length; i++)
        {
            cashFindedMatches.AddRange(FindMatch(tile, directions[i]));
        }

        if(cashFindedMatches.Count >= 2)
        {
            for(int i = 0; i < cashFindedMatches.Count; i++)
            {
                cashFindedMatches[i].Sprite.sprite = Board.Instance.BoardSettings.Swap;
            }
            _isFindMatch = true;
        }
    }

    private void FindAllMatches(Tile tile)
    {
        ReplaceTile(tile, new Vector2[] { Vector2.up, Vector2.down });
        ReplaceTile(tile, new Vector2[] { Vector2.left, Vector2.right });

        if (_isFindMatch)
        {
            _isFindMatch = false;
            tile.Sprite.sprite = Board.Instance.BoardSettings.Swap;
        }
    }
}
