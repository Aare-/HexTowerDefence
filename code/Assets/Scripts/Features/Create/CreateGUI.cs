using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CreateGUI : IInitializeSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()            
             .AddResource(ResourceComponent.ViewContainer.ui, "game_ui");
    }
}
