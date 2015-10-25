namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddEnemiesSystem() {
            return this.CreateSystem<AddEnemiesSystem>();
        }
    }
}