using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Vfx
{
    public class ColorBlinkEffectInstaller : Installer<BlinkableVFXData, ColorBlinkEffectInstaller>
    {
        [Inject]
        private BlinkableVFXData _data;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ColorBlinkEffect>()
                     .AsSingle()
                     .WithArguments(_data.Color, _data.Renderer, _data.Duration, _data.Frequency);
        }
    }
}