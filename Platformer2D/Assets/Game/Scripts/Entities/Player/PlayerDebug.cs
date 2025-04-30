using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Jump;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Player
{
    public class PlayerDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IPlayerInput _playerInput;

        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private PlayerView _playerView;

        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IEntity _entity;
        
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private ICharacterJumper _jumper;
        
        [Inject, ShowInInspector, HideInEditorMode]
        private Player _player;

        [Inject(Id = ImpactKeys.Push), ShowInInspector, HideInEditorMode]
        private CharacterPusher _pusher;

        [Inject(Id = ImpactKeys.Toss), ShowInInspector, HideInEditorMode]
        private CharacterPusher _tosser;
        
    }
}