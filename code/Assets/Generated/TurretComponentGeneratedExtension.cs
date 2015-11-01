using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public TurretComponent turret { get { return (TurretComponent)GetComponent(ComponentIds.Turret); } }

        public bool hasTurret { get { return HasComponent(ComponentIds.Turret); } }

        static readonly Stack<TurretComponent> _turretComponentPool = new Stack<TurretComponent>();

        public static void ClearTurretComponentPool() {
            _turretComponentPool.Clear();
        }

        public Entity AddTurret(float newRateOfFire, float newPower) {
            var component = _turretComponentPool.Count > 0 ? _turretComponentPool.Pop() : new TurretComponent();
            component.rateOfFire = newRateOfFire;
            component.power = newPower;
            return AddComponent(ComponentIds.Turret, component);
        }

        public Entity ReplaceTurret(float newRateOfFire, float newPower) {
            var previousComponent = hasTurret ? turret : null;
            var component = _turretComponentPool.Count > 0 ? _turretComponentPool.Pop() : new TurretComponent();
            component.rateOfFire = newRateOfFire;
            component.power = newPower;
            ReplaceComponent(ComponentIds.Turret, component);
            if (previousComponent != null) {
                _turretComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTurret() {
            var component = turret;
            RemoveComponent(ComponentIds.Turret);
            _turretComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTurret;

        public static IMatcher Turret {
            get {
                if (_matcherTurret == null) {
                    _matcherTurret = Matcher.AllOf(ComponentIds.Turret);
                }

                return _matcherTurret;
            }
        }
    }
}
