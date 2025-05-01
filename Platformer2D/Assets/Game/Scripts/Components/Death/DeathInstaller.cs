using UnityEngine;
using Zenject;

namespace Game.Scripts.Death
{
    public class DeathInstaller : Installer<GameObject, DeathInstaller>
    {
        private readonly GameObject _target;

        public DeathInstaller(GameObject target)
        {
            _target = target;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DeathUseCase>()
                     .AsSingle()
                     .WithArguments(_target);
        }
    }
}