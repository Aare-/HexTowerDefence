using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public HexPosition hexPosition { get { return (HexPosition)GetComponent(ComponentIds.HexPosition); } }

        public bool hasHexPosition { get { return HasComponent(ComponentIds.HexPosition); } }

        static readonly Stack<HexPosition> _hexPositionComponentPool = new Stack<HexPosition>();

        public static void ClearHexPositionComponentPool() {
            _hexPositionComponentPool.Clear();
        }

        public Entity AddHexPosition(int newX, int newY, int newZ, float newElevation) {
            var component = _hexPositionComponentPool.Count > 0 ? _hexPositionComponentPool.Pop() : new HexPosition();
            component.x = newX;
            component.y = newY;
            component.z = newZ;
            component.elevation = newElevation;
            return AddComponent(ComponentIds.HexPosition, component);
        }

        public Entity ReplaceHexPosition(int newX, int newY, int newZ, float newElevation) {
            var previousComponent = hasHexPosition ? hexPosition : null;
            var component = _hexPositionComponentPool.Count > 0 ? _hexPositionComponentPool.Pop() : new HexPosition();
            component.x = newX;
            component.y = newY;
            component.z = newZ;
            component.elevation = newElevation;
            ReplaceComponent(ComponentIds.HexPosition, component);
            if (previousComponent != null) {
                _hexPositionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveHexPosition() {
            var component = hexPosition;
            RemoveComponent(ComponentIds.HexPosition);
            _hexPositionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHexPosition;

        public static IMatcher HexPosition {
            get {
                if (_matcherHexPosition == null) {
                    _matcherHexPosition = Matcher.AllOf(ComponentIds.HexPosition);
                }

                return _matcherHexPosition;
            }
        }
    }
}
