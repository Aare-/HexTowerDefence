namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddHexTile() {
            return this.CreateSystem<AddHexTile>();
        }
    }
}