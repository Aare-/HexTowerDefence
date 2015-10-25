using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class RemoveViewSystem : IMultiReactiveSystem, ISetPool, IEnsureComponents {
    public TriggerOnEvent[] triggers {
        get {
            return new[] {
                Matcher.Resource.OnEntityRemoved(),
                Matcher.AllOf(Matcher.Resource, Matcher.Destroy).OnEntityAdded()
            };
        }
    }

    public IMatcher ensureComponents { get { return Matcher.View; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(Matcher.View).OnEntityRemoved += onEntityRemoved;
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component) {
        var viewComponent = (ViewComponent)component;
        Object.Destroy(viewComponent.gameObject);
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.RemoveView();
        }
    }
}
