using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class EnemyFactory {
    //TODO: refactor to use factory pattern correctly
    public static Entity CreateBasicEnemy(Entity e) {
        Vector2 _tmp = Quaternion.AngleAxis(360.0f * Random.Range(0.0f, 1.0f), Vector3.forward) * Vector2.up;
        Vector3 pos = new Vector3(_tmp.x, 0.0f, _tmp.y);
        pos.Normalize();
        pos *= GameController.Instance.EnemySpawnRadius;

        e
         .AddNestedView(SceneRoot.GAME_SCENE)
         .AddResource(GameController.Instance.ResourcesEnemiesPrefix + "/enemy_basic")
         .AddPosition(pos.x, GameController.Instance.EnemySpawnY, pos.z)
         .AddMovable(GameController.Instance.EnemyVelocity);

        return e;
    }
}

