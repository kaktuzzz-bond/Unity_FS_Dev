using Game.Scripts.Components.Health;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trap
{
    public class TrapDebug:MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IDamagable _health;
        
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IDamagableBody _damagableBody;
    }
}