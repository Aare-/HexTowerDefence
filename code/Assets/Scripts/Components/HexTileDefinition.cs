using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexTileDefinition : IComponent {
    public enum TileType {
        tile_grass,
        tile_grass_mushrooms,
        tile_grass_trees
    }

    public TileType type;
}