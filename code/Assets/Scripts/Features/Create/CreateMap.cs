using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CreateMap : IInitializeSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .AddHexTileDefinition(
                (HexTileDefinition.TileType)System.Enum.GetValues(typeof(HexTileDefinition.TileType)).GetRandomElement())
            .AddHexPosition(0, 0, 0, Random.Range(0, 3));            
    }
}