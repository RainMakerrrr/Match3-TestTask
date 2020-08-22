using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoardSettings
{
    public int xSize, ySize;
    public Tile Tile;
    public Sprite Swap;
    public Sprite Match;
    public List<Sprite> Sprites;
}
