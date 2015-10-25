namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddMapSystem() {
            return this.CreateSystem<AddMapSystem>();
        }
    }
}