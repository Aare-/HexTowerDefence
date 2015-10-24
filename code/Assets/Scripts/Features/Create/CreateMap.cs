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
        int size = 2;

        for (int i = -size; i <= size; i++) {
            for(int j = Mathf.Max(-size, -i-size); j <= Mathf.Min(size, -i+size); j++) {
                var k = -i - j;                 
                _pool.CreateEntity()
                    .AddHexTileDefinition(
                    (HexTileDefinition.TileType)System.Enum.GetValues(typeof(HexTileDefinition.TileType)).GetRandomElement())
                    .AddHexPosition(i, j, k, 0);
            }            
        }            
    }
}