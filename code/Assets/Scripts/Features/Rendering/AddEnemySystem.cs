using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AddEnemiesSystem : IReactiveSystem {
     public TriggerOnEvent trigger { get {  return Matcher.AllOf(Matcher.Enemy).OnEntityAdded(); }}

     public void Execute(List<Entity> entities) {
         foreach (Entity e in entities) {                                                   
            Vector2 _tmp = Quaternion.AngleAxis(360.0f * Random.Range(0.0f, 1.0f), Vector3.forward) * Vector2.up;
            Vector3 pos = new Vector3(_tmp.x, 0.0f, _tmp.y);
            pos.Normalize();
            pos *= GameController.Instance.EnemySpawnRadius;

            e.AddResource(
                ResourceComponent.ViewContainer.game_scene,
                GameController.Instance.ResourcesEnemiesPrefix + "/enemy_basic")
             .AddPosition(pos.x, GameController.Instance.EnemySpawnY, pos.z)
             .AddMovable(GameController.Instance.EnemyVelocity);
         }
     }
}
