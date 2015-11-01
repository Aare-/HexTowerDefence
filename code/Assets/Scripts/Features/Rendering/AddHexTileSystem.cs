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
            string resourcePath;
            resourcePath = 
                GameController.Instance.ResourcesTilessPrefix + "/" +  
                    (e.hexTileDefinition.isBlocked ?
                        Enum.GetValues(typeof(HexTileDefinitionComponent.BlockedTileType)).GetRandomElement() : 
                        e.hexTileDefinition.type.ToString());

            e.ReplaceNestedView(SceneRoot.GAME_SCENE);
            e.ReplaceResource(resourcePath);                                        
        }
    }
}