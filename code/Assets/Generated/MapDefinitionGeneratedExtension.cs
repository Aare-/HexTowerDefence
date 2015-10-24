using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public MapDefinition mapDefinition { get { return (MapDefinition)GetComponent(ComponentIds.MapDefinition); } }

        public bool hasMapDefinition { get { return HasComponent(ComponentIds.MapDefinition); } }

        static readonly Stack<MapDefinition> _mapDefinitionComponentPool = new Stack<MapDefinition>();

        public static void ClearMapDefinitionComponentPool() {
            _mapDefinitionComponentPool.Clear();
        }

        public Entity AddMapDefinition(int newRadius) {
            var component = _mapDefinitionComponentPool.Count > 0 ? _mapDefinitionComponentPool.Pop() : new MapDefinition();
            component.radius = newRadius;
            return AddComponent(ComponentIds.MapDefinition, component);
        }

        public Entity ReplaceMapDefinition(int newRadius) {
            var previousComponent = hasMapDefinition ? mapDefinition : null;
            var component = _mapDefinitionComponentPool.Count > 0 ? _mapDefinitionComponentPool.Pop() : new MapDefinition();
            component.radius = newRadius;
            ReplaceComponent(ComponentIds.MapDefinition, component);
            if (previousComponent != null) {
                _mapDefinitionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMapDefinition() {
            var component = mapDefinition;
            RemoveComponent(ComponentIds.MapDefinition);
            _mapDefinitionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMapDefinition;

        public static IMatcher MapDefinition {
            get {
                if (_matcherMapDefinition == null) {
                    _matcherMapDefinition = Matcher.AllOf(ComponentIds.MapDefinition);
                }

                return _matcherMapDefinition;
            }
        }
    }
}
