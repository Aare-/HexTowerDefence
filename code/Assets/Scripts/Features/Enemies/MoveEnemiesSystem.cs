using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MoveEnemiesSystem : IExecuteSystem, ISetPool {    
    Group _group;

    public void SetPool(Pool pool) {
        //_group = pool.GetGroup(Matcher.AllOf(Matcher.Ene));
    }

    public void Execute() {
        /*foreach (var e in _group.GetEntities()) {
            var move = e.move;
            var pos = e.position;
            e.ReplacePosition(pos.x, pos.y + move.speed, pos.z);
        }*/
    }
}
