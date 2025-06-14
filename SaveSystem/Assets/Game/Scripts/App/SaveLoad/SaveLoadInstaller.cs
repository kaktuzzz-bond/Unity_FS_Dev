using UnityEngine;
using Zenject;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = nameof(SaveLoadInstaller),
        menuName = "Zenject/New SaveLoad Installer")]
    public class SaveLoadInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //learning example
            Container.Bind<ValueProvider>()
                     .AsSingle();

            Container.Bind<GameSaveLoader>()
                     .AsSingle();

            Container.BindInterfacesTo<ValueSerializer>()
                     .AsSingle();
        }
    }
}