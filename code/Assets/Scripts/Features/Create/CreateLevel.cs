using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CreateLevel : IInitializeSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()            
             .AddPosition(0, 0, 0)
             .AddResource("scene_level");
    }
}
