using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexTileDefinitionComponent : IComponent {
    public enum TileType {
        tile_grass,
        tile_grass_mushrooms,        
    }
    public enum BlockedTileType {
        tile_grass_trees
    }

    public TileType type;
    public bool isBlocked;
}