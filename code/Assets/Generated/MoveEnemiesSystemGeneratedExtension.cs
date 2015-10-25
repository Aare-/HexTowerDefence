namespace Entitas {
    public partial class Pool {
        public ISystem CreateMoveEnemiesSystem() {
            return this.CreateSystem<MoveEnemiesSystem>();
        }
    }
}