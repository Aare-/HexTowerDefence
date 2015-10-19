namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateLevel() {
            return this.CreateSystem<CreateLevel>();
        }
    }
}