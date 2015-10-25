using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public TurretDefinition turretDefinition { get { return (TurretDefinition)GetComponent(ComponentIds.TurretDefinition); } }

        public bool hasTurretDefinition { get { return HasComponent(ComponentIds.TurretDefinition); } }

        static readonly Stack<TurretDefinition> _turretDefinitionComponentPool = new Stack<TurretDefinition>();

        public static void ClearTurretDefinitionComponentPool() {
            _turretDefinitionComponentPool.Clear();
        }

        public Entity AddTurretDefinition(float newRateOfFire, float newPower) {
            var component = _turretDefinitionComponentPool.Count > 0 ? _turretDefinitionComponentPool.Pop() : new TurretDefinition();
            component.rateOfFire = newRateOfFire;
            component.power = newPower;
            return AddComponent(ComponentIds.TurretDefinition, component);
        }

        public Entity ReplaceTurretDefinition(float newRateOfFire, float newPower) {
            var previousComponent = hasTurretDefinition ? turretDefinition : null;
            var component = _turretDefinitionComponentPool.Count > 0 ? _turretDefinitionComponentPool.Pop() : new TurretDefinition();
            component.rateOfFire = newRateOfFire;
            component.power = newPower;
            ReplaceComponent(ComponentIds.TurretDefinition, component);
            if (previousComponent != null) {
                _turretDefinitionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTurretDefinition() {
            var component = turretDefinition;
            RemoveComponent(ComponentIds.TurretDefinition);
            _turretDefinitionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTurretDefinition;

        public static IMatcher TurretDefinition {
            get {
                if (_matcherTurretDefinition == null) {
                    _matcherTurretDefinition = Matcher.AllOf(ComponentIds.TurretDefinition);
                }

                return _matcherTurretDefinition;
            }
        }
    }
}
