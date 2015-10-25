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
    }

    void Update() {
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

            // Render            
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<AddMapSystem>())
            .Add(pool.CreateSystem<AddHexTileSystem>())
            .Add(pool.CreateSystem<PositionHexSystem>())            
            .Add(pool.CreateSystem<PositionCartesianSystem>())            
            
            //Destroy
            .Add(pool.CreateSystem<RemoveViewSystem>())
            ;        
    }
}

