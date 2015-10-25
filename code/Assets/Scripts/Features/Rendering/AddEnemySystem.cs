using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AddEnemiesSystem : IReactiveSystem {
     public TriggerOnEvent trigger { get {  return Matcher.AllOf(Matcher.Enemy).OnEntityAdded(); }}

     public void Execute(List<Entity> entities) {
         foreach (Entity e in entities) {                          
            e.AddResource(
                ResourceComponent.ViewContainer.game_scene,
                GameController.Instance.ResourcesEnemiesPrefix + "/enemy_basic")
             .AddHexPosition(2, -2, 0, 0);


             

         }
     }
}
