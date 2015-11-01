using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public MovableComponent movable { get { return (MovableComponent)GetComponent(ComponentIds.Movable); } }

        public bool hasMovable { get { return HasComponent(ComponentIds.Movable); } }

        static readonly Stack<MovableComponent> _movableComponentPool = new Stack<MovableComponent>();

        public static void ClearMovableComponentPool() {
            _movableComponentPool.Clear();
        }

        public Entity AddMovable(float newVelocity) {
            var component = _movableComponentPool.Count > 0 ? _movableComponentPool.Pop() : new MovableComponent();
            component.velocity = newVelocity;
            return AddComponent(ComponentIds.Movable, component);
        }

        public Entity ReplaceMovable(float newVelocity) {
            var previousComponent = hasMovable ? movable : null;
            var component = _movableComponentPool.Count > 0 ? _movableComponentPool.Pop() : new MovableComponent();
            component.velocity = newVelocity;
            ReplaceComponent(ComponentIds.Movable, component);
            if (previousComponent != null) {
                _movableComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMovable() {
            var component = movable;
            RemoveComponent(ComponentIds.Movable);
            _movableComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMovable;

        public static IMatcher Movable {
            get {
                if (_matcherMovable == null) {
                    _matcherMovable = Matcher.AllOf(ComponentIds.Movable);
                }

                return _matcherMovable;
            }
        }
    }
}
