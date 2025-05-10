using System;

namespace Game.Scripts.Game.Core.Vfx
{
    public interface IVisualFX
    {
        void Play(Action callback);
    }
}