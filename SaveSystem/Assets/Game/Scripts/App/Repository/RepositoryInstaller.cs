using UnityEngine;
using Zenject;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = nameof(RepositoryInstaller),
        menuName = "Zenject/New Repository Installer")]
    public class RepositoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private string fileName = "Value.txt";

        [SerializeField]
        private string aesPassword = "123";

        [SerializeField]
        private byte[] aesSalt = { 0x52, 0x41, 0x16, 0x79, 0x86, 0x64, 0x97, 0x22 };

        private string FilePath => $"{Application.streamingAssetsPath}/{fileName}";

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameRepository>()
                     .AsSingle()
                     .WithArguments(FilePath, aesPassword, aesSalt);
        }
    }
}