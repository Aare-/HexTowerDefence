using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public MapSize mapSize { get { return (MapSize)GetComponent(ComponentIds.MapSize); } }

        public bool hasMapSize { get { return HasComponent(ComponentIds.MapSize); } }

        static readonly Stack<MapSize> _mapSizeComponentPool = new Stack<MapSize>();

        public static void ClearMapSizeComponentPool() {
            _mapSizeComponentPool.Clear();
        }

        public Entity AddMapSize(int newRadius) {
            var component = _mapSizeComponentPool.Count > 0 ? _mapSizeComponentPool.Pop() : new MapSize();
            component.radius = newRadius;
            return AddComponent(ComponentIds.MapSize, component);
        }

        public Entity ReplaceMapSize(int newRadius) {
            var previousComponent = hasMapSize ? mapSize : null;
            var component = _mapSizeComponentPool.Count > 0 ? _mapSizeComponentPool.Pop() : new MapSize();
            component.radius = newRadius;
            ReplaceComponent(ComponentIds.MapSize, component);
            if (previousComponent != null) {
                _mapSizeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMapSize() {
            var component = mapSize;
            RemoveComponent(ComponentIds.MapSize);
            _mapSizeComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMapSize;

        public static IMatcher MapSize {
            get {
                if (_matcherMapSize == null) {
                    _matcherMapSize = Matcher.AllOf(ComponentIds.MapSize);
                }

                return _matcherMapSize;
            }
        }
    }
}
