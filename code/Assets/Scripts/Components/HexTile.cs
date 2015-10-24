using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexTile : IComponent {
    public enum HexTileType {
        tile_grass,
        tile_grass_mushroom,
        tile_grass_trees
    }

    public int x;
    public int y;
    public int z;
    public int elevation;
}
