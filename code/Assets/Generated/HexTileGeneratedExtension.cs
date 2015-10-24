using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public HexTile hexTile { get { return (HexTile)GetComponent(ComponentIds.HexTile); } }

        public bool hasHexTile { get { return HasComponent(ComponentIds.HexTile); } }

        static readonly Stack<HexTile> _hexTileComponentPool = new Stack<HexTile>();

        public static void ClearHexTileComponentPool() {
            _hexTileComponentPool.Clear();
        }

        public Entity AddHexTile(int newX, int newY, int newZ, int newElevation) {
            var component = _hexTileComponentPool.Count > 0 ? _hexTileComponentPool.Pop() : new HexTile();
            component.x = newX;
            component.y = newY;
            component.z = newZ;
            component.elevation = newElevation;
            return AddComponent(ComponentIds.HexTile, component);
        }

        public Entity ReplaceHexTile(int newX, int newY, int newZ, int newElevation) {
            var previousComponent = hasHexTile ? hexTile : null;
            var component = _hexTileComponentPool.Count > 0 ? _hexTileComponentPool.Pop() : new HexTile();
            component.x = newX;
            component.y = newY;
            component.z = newZ;
            component.elevation = newElevation;
            ReplaceComponent(ComponentIds.HexTile, component);
            if (previousComponent != null) {
                _hexTileComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveHexTile() {
            var component = hexTile;
            RemoveComponent(ComponentIds.HexTile);
            _hexTileComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHexTile;

        public static IMatcher HexTile {
            get {
                if (_matcherHexTile == null) {
                    _matcherHexTile = Matcher.AllOf(ComponentIds.HexTile);
                }

                return _matcherHexTile;
            }
        }
    }
}
