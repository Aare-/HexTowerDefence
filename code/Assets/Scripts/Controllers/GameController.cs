using Entitas;
using Entitas.Unity.VisualDebugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GameController : MonoBehaviour {    

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
            
            .Add(pool.CreateSystem<CreateLevel>())

            // Render            
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())            

            /*
            .Add(pool.CreateSystem<CreatePlayerSystem>())
            .Add(pool.CreateSystem<CreateOpponentsSystem>())
            .Add(pool.CreateSystem<CreateFinishLineSystem>())

            // Input
            .Add(pool.CreateSystem<InputSystem>())

            // Update
            .Add(pool.CreateSystem<AccelerateSystem>())
            .Add(pool.CreateSystem<MoveSystem>())
            .Add(pool.CreateSystem<ReachedFinishSystem>())

            // Render
            .Add(pool.CreateSystem<RemoveViewSystem>())
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())
            
            // Destroy
            .Add(pool.CreateSystem<DestroySystem>())
            */
            ;
    }
}

