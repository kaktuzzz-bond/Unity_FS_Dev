using Game.Scripts.Components.Entities;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, ReadOnly, HideInEditorMode]
        private IPlayerInput _playerInput;

        [Inject, ShowInInspector, ReadOnly, HideInEditorMode]
        private PlayerView _playerView;

        [Inject, ShowInInspector, ReadOnly, HideInEditorMode]
        private IEntity _entity;
        
        [Inject, ShowInInspector, HideInEditorMode]
        private Player _player;
    }
}