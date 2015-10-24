namespace Entitas {
    public partial class Pool {
        public ISystem CreatePositionHexSystem() {
            return this.CreateSystem<PositionHexSystem>();
        }
    }
}