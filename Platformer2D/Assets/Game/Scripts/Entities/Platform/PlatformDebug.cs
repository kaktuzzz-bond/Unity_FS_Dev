using Game.Scripts.Components.Movement.Move;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Platform
{
    public class PlatformDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode]
        private IPatrolComponent _patrolComponent;

        [Inject, ShowInInspector, HideInEditorMode]
        private IMoveComponent _moveComponent;
    }
}