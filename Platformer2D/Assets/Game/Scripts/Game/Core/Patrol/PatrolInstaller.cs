using Zenject;

namespace Game.Scripts.Game.Core.Patrol
{
    public class PatrolInstaller : Installer<PatrolData, PatrolInstaller>
    {
        [Inject]
        private readonly PatrolData _data;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Patrol>()
                     .AsSingle()
                     .WithArguments(_data.Body, _data.Waypoints);
        }
    }
}