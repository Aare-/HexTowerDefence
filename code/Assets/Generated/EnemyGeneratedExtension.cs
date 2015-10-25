namespace Entitas {
    public partial class Entity {
        static readonly Enemy enemyComponent = new Enemy();

        public bool isEnemy {
            get { return HasComponent(ComponentIds.Enemy); }
            set {
                if (value != isEnemy) {
                    if (value) {
                        AddComponent(ComponentIds.Enemy, enemyComponent);
                    } else {
                        RemoveComponent(ComponentIds.Enemy);
                    }
                }
            }
        }

        public Entity IsEnemy(bool value) {
            isEnemy = value;
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
