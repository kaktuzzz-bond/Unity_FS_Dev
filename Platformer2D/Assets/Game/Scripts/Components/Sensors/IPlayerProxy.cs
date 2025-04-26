using Game.Scripts.Player;


namespace Game.Scripts.Components.Sensors
{
    public interface IPlayerProxy
    {
        public IEntity GetEntity { get; }
    }
}