using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddTurretSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return (Matcher.TurretDefinition).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {

        foreach (Entity e in entities) {
            
        }
    }
}