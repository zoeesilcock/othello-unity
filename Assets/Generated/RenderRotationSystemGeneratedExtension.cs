namespace Entitas {
    public partial class Pool {
        public ISystem CreateRenderRotationSystem() {
            return this.CreateSystem<RenderRotationSystem>();
        }
    }
}