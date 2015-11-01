namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddNestedViewSystem() {
            return this.CreateSystem<AddNestedViewSystem>();
        }
    }
}