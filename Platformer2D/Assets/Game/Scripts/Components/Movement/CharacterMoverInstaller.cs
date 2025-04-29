using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class CharacterMoverInstaller : Installer<CharacterMoverInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterMover>()
                     .AsSingle();
        }
    }
}