namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateMap() {
            return this.CreateSystem<CreateMap>();
        }
    }
}