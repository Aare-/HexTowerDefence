using Entitas;
using Entitas.Unity.VisualDebugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class GameController : Singleton<GameController> {    
    Systems _systems;

    void Start() {        
        _systems = createSystems(Pools.pool);
        _systems.Initialize();

        #region Registering for events
        TinyTokenManager.Instance.Register<Msg.SpawnBasicEnemy>("SPAWN_ENEMY" + GetInstanceID(),
          (m) => {
              //TODO: proper factory pattern
              EnemyFactory.CreateBasicEnemy(Pools.pool.CreateEntity());
          });
        #endregion
    }
    void OnDestroy() {
        #region Unregistering from events
        TinyTokenManager.Instance.Unregister<Msg.SpawnBasicEnemy>("SPAWN_ENEMY" + GetInstanceID());
        #endregion
    }

    void Update() {
        UpdateEnemies();

        _systems.Execute();        
    }

    Systems createSystems(Pool pool) {
        #if (UNITY_EDITOR)
        return new DebugSystems()
        #else
        return new Systems()
        #endif            
            // Initialize                        
            .Add(pool.CreateSystem<InitGame>())

            // Update
            .Add(pool.CreateSystem<MovableSystem>())

            // Render                                  
            .Add(pool.CreateSystem<AddMapSystem>())            
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<AddNestedViewSystem>())
            .Add(pool.CreateSystem<AddHexTileSystem>())
            .Add(pool.CreateSystem<PositionHexSystem>())            
            .Add(pool.CreateSystem<PositionCartesianSystem>())            
            
            //Destroy
            .Add(pool.CreateSystem<RemoveViewSystem>())
            .Add(pool.CreateSystem<DestroySystem>())
            ;        
    }
}

