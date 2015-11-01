using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddMapSystem : IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.MapDefinition.OnEntityAdded(); } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            foreach (Entity hex in _pool.GetGroup(Matcher.HexTileDefinition).GetEntities())
                hex.IsDestroy(true);            

            int size = e.mapDefinition.radius;

            for (int i = -size; i <= size; i++) {
                for(int j = Mathf.Max(-size, -i-size); j <= Mathf.Min(size, -i+size); j++) {
                    var k = -i - j;
                    float elevation = 0.0f;

                    if (i == j && j == k && k == 0)
                        elevation = -1.0f;

                    _pool.CreateEntity()
                        .AddHexTileDefinition(
                            (HexTileDefinitionComponent.TileType)System.Enum.GetValues(typeof(HexTileDefinitionComponent.TileType)).GetRandomElement(),
                            Random.Range(0.0f, 1.0f) <= e.mapDefinition.chanceOfBlockedTile)
                        .AddHexPosition(i, j, k, elevation);
                }            
            }         
        }
    }
}
