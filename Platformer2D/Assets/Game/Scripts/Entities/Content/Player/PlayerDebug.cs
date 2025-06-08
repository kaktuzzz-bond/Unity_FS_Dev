using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class PlayerDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IEntity _entity;

        [Inject, ShowInInspector, HideInEditorMode]
        private Player _player;


        //
        // [Inject(Id = ImpactKeys.Push), ShowInInspector, HideInEditorMode]
        // private ICharacterPusher _pusher;
        //
        // [Inject(Id = ImpactKeys.Toss), ShowInInspector, HideInEditorMode]
        // private ICharacterPusher _tosser;
    }
}