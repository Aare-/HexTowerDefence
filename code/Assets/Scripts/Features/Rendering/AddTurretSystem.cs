using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddTurretSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(Matcher.TurretDefinition).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {

        foreach (Entity e in entities) {
            string resourcePath;
            resourcePath =
                GameController.Instance.ResourcesTilessPrefix + "/" +
                    (e.hexTileDefinition.isBlocked ?
                        Enum.GetValues(typeof(HexTileDefinition.BlockedTileType)).GetRandomElement() :
                        e.hexTileDefinition.type.ToString());

            if (e.hasResource)
                e.ReplaceResource(
                    ResourceComponent.ViewContainer.game_scene,
                    resourcePath);
            else
                e.AddResource(
                    ResourceComponent.ViewContainer.game_scene,
                    resourcePath);
        }
    }
}