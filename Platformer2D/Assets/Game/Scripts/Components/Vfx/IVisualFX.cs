using System;

namespace Game.Scripts.Components.Vfx
{
    public interface IVisualFX
    {
        void Play(Action callback);
    }
}