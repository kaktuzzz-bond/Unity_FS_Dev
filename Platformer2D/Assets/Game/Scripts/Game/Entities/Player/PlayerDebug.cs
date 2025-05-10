using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Impacts;
using Game.Scripts.Game.Core.Impacts.Pusher;
using Game.Scripts.Game.Core.Jump;
using Game.Scripts.GameSystem.PlayerInput;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class PlayerDebug : MonoBehaviour
    {
        // [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        // private IPlayerInput _playerInput;
        
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IEntity _entity;
        
        [Inject, ShowInInspector, HideInEditorMode]
        private Player _player;
        
        
        //
        // [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        // private IHealthComponent _health;
        //
        // [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        // private ICharacterJumper _jumper;
        //
      
        //
        // [Inject(Id = ImpactKeys.Push), ShowInInspector, HideInEditorMode]
        // private ICharacterPusher _pusher;
        //
        // [Inject(Id = ImpactKeys.Toss), ShowInInspector, HideInEditorMode]
        // private ICharacterPusher _tosser;
        
    }
}