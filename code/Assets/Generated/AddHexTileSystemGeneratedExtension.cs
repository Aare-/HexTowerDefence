namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddHexTileSystem() {
            return this.CreateSystem<AddHexTileSystem>();
        }
    }
}