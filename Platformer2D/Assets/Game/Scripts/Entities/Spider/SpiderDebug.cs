using Game.Scripts.Components.Health;
using Game.Scripts.Components.Patrol;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Spider
{
    public class SpiderDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IPatrolable _patrolComponent;


        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IDamagableBody _damagableBody;

        [Inject, ShowInInspector, HideInEditorMode, ReadOnly]
        private IDamagable _health;
        
        [Inject, ShowInInspector, HideInEditorMode]
        private Spider _spider;
    }
}