using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class CharacterMoverInstaller : Installer<MovementData, CharacterMoverInstaller>
    {
        [Inject]
        private readonly MovementData _data;

        public override void InstallBindings()
        {
            MoveInstaller.Install(Container, _data);

            Container.BindInterfacesTo<CharacterMover>()
                     .AsSingle();
        }
    }
}