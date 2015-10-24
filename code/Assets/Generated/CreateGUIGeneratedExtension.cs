namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateGUI() {
            return this.CreateSystem<CreateGUI>();
        }
    }
}