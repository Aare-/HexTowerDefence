using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Enemy enemy { get { return (Enemy)GetComponent(ComponentIds.Enemy); } }

        public bool hasEnemy { get { return HasComponent(ComponentIds.Enemy); } }

        static readonly Stack<Enemy> _enemyComponentPool = new Stack<Enemy>();

        public static void ClearEnemyComponentPool() {
            _enemyComponentPool.Clear();
        }

        public Entity AddEnemy(float newLife) {
            var component = _enemyComponentPool.Count > 0 ? _enemyComponentPool.Pop() : new Enemy();
            component.life = newLife;
            return AddComponent(ComponentIds.Enemy, component);
        }

        public Entity ReplaceEnemy(float newLife) {
            var previousComponent = hasEnemy ? enemy : null;
            var component = _enemyComponentPool.Count > 0 ? _enemyComponentPool.Pop() : new Enemy();
            component.life = newLife;
            ReplaceComponent(ComponentIds.Enemy, component);
            if (previousComponent != null) {
                _enemyComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveEnemy() {
            var component = enemy;
            RemoveComponent(ComponentIds.Enemy);
            _enemyComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherEnemy;

        public static IMatcher Enemy {
            get {
                if (_matcherEnemy == null) {
                    _matcherEnemy = Matcher.AllOf(ComponentIds.Enemy);
                }

                return _matcherEnemy;
            }
        }
    }
}
