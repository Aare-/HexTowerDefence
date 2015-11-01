using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public AliveComponent alive { get { return (AliveComponent)GetComponent(ComponentIds.Alive); } }

        public bool hasAlive { get { return HasComponent(ComponentIds.Alive); } }

        static readonly Stack<AliveComponent> _aliveComponentPool = new Stack<AliveComponent>();

        public static void ClearAliveComponentPool() {
            _aliveComponentPool.Clear();
        }

        public Entity AddAlive(float newLife) {
            var component = _aliveComponentPool.Count > 0 ? _aliveComponentPool.Pop() : new AliveComponent();
            component.life = newLife;
            return AddComponent(ComponentIds.Alive, component);
        }

        public Entity ReplaceAlive(float newLife) {
            var previousComponent = hasAlive ? alive : null;
            var component = _aliveComponentPool.Count > 0 ? _aliveComponentPool.Pop() : new AliveComponent();
            component.life = newLife;
            ReplaceComponent(ComponentIds.Alive, component);
            if (previousComponent != null) {
                _aliveComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveAlive() {
            var component = alive;
            RemoveComponent(ComponentIds.Alive);
            _aliveComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAlive;

        public static IMatcher Alive {
            get {
                if (_matcherAlive == null) {
                    _matcherAlive = Matcher.AllOf(ComponentIds.Alive);
                }

                return _matcherAlive;
            }
        }
    }
}
