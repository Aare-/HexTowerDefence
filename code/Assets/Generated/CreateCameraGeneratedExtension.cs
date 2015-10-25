namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateCamera() {
            return this.CreateSystem<CreateCamera>();
        }
    }
}