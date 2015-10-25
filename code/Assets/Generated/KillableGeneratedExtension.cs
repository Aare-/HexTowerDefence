using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Killable killable { get { return (Killable)GetComponent(ComponentIds.Killable); } }

        public bool hasKillable { get { return HasComponent(ComponentIds.Killable); } }

        static readonly Stack<Killable> _killableComponentPool = new Stack<Killable>();

        public static void ClearKillableComponentPool() {
            _killableComponentPool.Clear();
        }

        public Entity AddKillable(float newLife) {
            var component = _killableComponentPool.Count > 0 ? _killableComponentPool.Pop() : new Killable();
            component.life = newLife;
            return AddComponent(ComponentIds.Killable, component);
        }

        public Entity ReplaceKillable(float newLife) {
            var previousComponent = hasKillable ? killable : null;
            var component = _killableComponentPool.Count > 0 ? _killableComponentPool.Pop() : new Killable();
            component.life = newLife;
            ReplaceComponent(ComponentIds.Killable, component);
            if (previousComponent != null) {
                _killableComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveKillable() {
            var component = killable;
            RemoveComponent(ComponentIds.Killable);
            _killableComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherKillable;

        public static IMatcher Killable {
            get {
                if (_matcherKillable == null) {
                    _matcherKillable = Matcher.AllOf(ComponentIds.Killable);
                }

                return _matcherKillable;
            }
        }
    }
}
