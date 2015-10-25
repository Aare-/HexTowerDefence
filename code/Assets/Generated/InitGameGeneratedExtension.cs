namespace Entitas {
    public partial class Pool {
        public ISystem CreateInitGame() {
            return this.CreateSystem<InitGame>();
        }
    }
}