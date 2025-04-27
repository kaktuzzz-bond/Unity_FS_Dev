using UnityEngine;

namespace Game.Scripts.Player.Settings
{
    [CreateAssetMenu(fileName = "EntitySettings", menuName = "Game/Entity Settings", order = 0)]
    public class EntityConfig : ScriptableObject
    {
        [field: SerializeField]
        public MoveSettings MoveSettings { get; private set; }

        [field: SerializeField]
        public JumpSettings JumpSettings { get; private set; }

        [field: SerializeField]
        public HealthSettings HealthSettings { get; private set; }

        [field: SerializeField]
        public AttackSettings AttackSettings { get; private set; }
        
        [field: SerializeField]
        public PushSettings PushSettings { get; private set; }
    }
}
