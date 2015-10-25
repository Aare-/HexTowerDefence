using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MoveEnemiesSystem : IExecuteSystem, ISetPool {
    Pool _pool;
    Group _group;
    float deltaSpawnTime = 0.0f;

    public void SetPool(Pool pool) {
        _pool = pool;
        _group = pool.GetGroup(Matcher.AllOf(Matcher.Enemy, Matcher.Position, Matcher.Movable, Matcher.View));
    }

    public void Execute() {
        foreach (var e in _group.GetEntities()) {            
            float delta = e.movable.velocity * Time.deltaTime;

            Vector3 direction = new Vector3(e.position.x, 0, e.position.z);
            Vector3 pos = new Vector3(direction.x, e.position.y, direction.z);
            direction.Normalize();
            direction *= delta;

            pos -= direction;                        
            
            e.ReplacePosition(pos.x, pos.y, pos.z);

            Vector2 pos2d = new Vector2(pos.x, pos.z);
            float angle = Vector2.Angle(pos2d, Vector2.right);
            e.view.gameObject.transform.rotation.SetEulerAngles(0.0f, 0.0f, angle * Mathf.Deg2Rad);

            if (pos2d.magnitude < 0.4f) {
                e.destroy();
                e.Release();
            }
        }

        deltaSpawnTime -= Time.deltaTime;
        if (deltaSpawnTime < 0.0f) {
            _pool.CreateEntity()
                .AddEnemy(100.0f);
            deltaSpawnTime = GameController.Instance.EnemySpawnDeltaTime;
        }
    }
}
