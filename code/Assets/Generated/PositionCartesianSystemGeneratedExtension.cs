namespace Entitas {
    public partial class Pool {
        public ISystem CreatePositionCartesianSystem() {
            return this.CreateSystem<PositionCartesianSystem>();
        }
    }
}