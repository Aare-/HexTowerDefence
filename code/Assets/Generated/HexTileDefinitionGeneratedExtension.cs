using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public HexTileDefinition hexTileDefinition { get { return (HexTileDefinition)GetComponent(ComponentIds.HexTileDefinition); } }

        public bool hasHexTileDefinition { get { return HasComponent(ComponentIds.HexTileDefinition); } }

        static readonly Stack<HexTileDefinition> _hexTileDefinitionComponentPool = new Stack<HexTileDefinition>();

        public static void ClearHexTileDefinitionComponentPool() {
            _hexTileDefinitionComponentPool.Clear();
        }

        public Entity AddHexTileDefinition(HexTileDefinition.TileType newType) {
            var component = _hexTileDefinitionComponentPool.Count > 0 ? _hexTileDefinitionComponentPool.Pop() : new HexTileDefinition();
            component.type = newType;
            return AddComponent(ComponentIds.HexTileDefinition, component);
        }

        public Entity ReplaceHexTileDefinition(HexTileDefinition.TileType newType) {
            var previousComponent = hasHexTileDefinition ? hexTileDefinition : null;
            var component = _hexTileDefinitionComponentPool.Count > 0 ? _hexTileDefinitionComponentPool.Pop() : new HexTileDefinition();
            component.type = newType;
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
