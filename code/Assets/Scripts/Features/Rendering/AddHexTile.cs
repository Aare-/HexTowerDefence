using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddHexTile : IReactiveSystem {    
    public TriggerOnEvent trigger {         
        get {  return Matcher.AllOf(Matcher.View, Matcher.HexTile).OnEntityAdded(); } 
    }

    public void Execute(List<Entity> entities) {
        foreach (Entity e in entities) {
            //e.view.gameObject.transform.position
        }
    }
}