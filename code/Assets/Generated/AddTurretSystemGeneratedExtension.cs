namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddTurretSystem() {
            return this.CreateSystem<AddTurretSystem>();
        }
    }
}