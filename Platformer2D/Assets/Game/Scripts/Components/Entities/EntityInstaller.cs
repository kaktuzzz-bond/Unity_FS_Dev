using Zenject;

namespace Game.Scripts.Components.Entities
{
    public class EntityInstaller : Installer<EntityInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle()
                     .WithArguments(Container);
        }
    }
}