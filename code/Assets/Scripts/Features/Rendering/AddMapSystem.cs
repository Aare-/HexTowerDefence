﻿using Entitas;
using System;
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
                hex.destroy();            

            int size = e.mapDefinition.radius;

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
}
