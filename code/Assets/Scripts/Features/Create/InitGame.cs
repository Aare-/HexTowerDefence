using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InitGame : IInitializeSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {        
        //initialisating map
        _pool.CreateEntity()
             .AddMapDefinition(GameController.Instance.MapRadius, 0.2f);
    }
}
