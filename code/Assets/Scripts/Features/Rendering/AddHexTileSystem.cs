using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddHexTileSystem : IReactiveSystem {    
    public TriggerOnEvent trigger { get {  return Matcher.AllOf(Matcher.HexTileDefinition).OnEntityAdded(); }}    

    public void Execute(List<Entity> entities) {
        foreach (Entity e in entities) {
            if(e.hasResource)
                e.ReplaceResource(
                    ResourceComponent.ViewContainer.game_scene,
                    GameController.Instance.ResourcesTilessPrefix + "/" + e.hexTileDefinition.type.ToString());                
            else 
                e.AddResource(
                    ResourceComponent.ViewContainer.game_scene,
                    GameController.Instance.ResourcesTilessPrefix + "/" + e.hexTileDefinition.type.ToString());                        
        }
    }
}