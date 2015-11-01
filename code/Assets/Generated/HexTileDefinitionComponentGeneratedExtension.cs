using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public HexTileDefinitionComponent hexTileDefinition { get { return (HexTileDefinitionComponent)GetComponent(ComponentIds.HexTileDefinition); } }

        public bool hasHexTileDefinition { get { return HasComponent(ComponentIds.HexTileDefinition); } }

        static readonly Stack<HexTileDefinitionComponent> _hexTileDefinitionComponentPool = new Stack<HexTileDefinitionComponent>();

        public static void ClearHexTileDefinitionComponentPool() {
            _hexTileDefinitionComponentPool.Clear();
        }

        public Entity AddHexTileDefinition(HexTileDefinitionComponent.TileType newType, bool newIsBlocked) {
            var component = _hexTileDefinitionComponentPool.Count > 0 ? _hexTileDefinitionComponentPool.Pop() : new HexTileDefinitionComponent();
            component.type = newType;
            component.isBlocked = newIsBlocked;
            return AddComponent(ComponentIds.HexTileDefinition, component);
        }

        public Entity ReplaceHexTileDefinition(HexTileDefinitionComponent.TileType newType, bool newIsBlocked) {
            var previousComponent = hasHexTileDefinition ? hexTileDefinition : null;
            var component = _hexTileDefinitionComponentPool.Count > 0 ? _hexTileDefinitionComponentPool.Pop() : new HexTileDefinitionComponent();
            component.type = newType;
            component.isBlocked = newIsBlocked;
            ReplaceComponent(ComponentIds.HexTileDefinition, component);
            if (previousComponent != null) {
                _hexTileDefinitionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveHexTileDefinition() {
            var component = hexTileDefinition;
            RemoveComponent(ComponentIds.HexTileDefinition);
            _hexTileDefinitionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHexTileDefinition;

        public static IMatcher HexTileDefinition {
            get {
                if (_matcherHexTileDefinition == null) {
                    _matcherHexTileDefinition = Matcher.AllOf(ComponentIds.HexTileDefinition);
                }

                return _matcherHexTileDefinition;
            }
        }
    }
}
