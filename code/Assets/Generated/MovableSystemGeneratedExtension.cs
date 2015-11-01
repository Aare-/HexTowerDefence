namespace Entitas {
    public partial class Pool {
        public ISystem CreateMovableSystem() {
            return this.CreateSystem<MovableSystem>();
        }
    }
}