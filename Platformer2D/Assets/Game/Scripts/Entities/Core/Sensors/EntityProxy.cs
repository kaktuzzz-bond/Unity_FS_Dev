using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class EntityProxy : MonoBehaviour, IEntityProxy
    {
        [Inject, ShowInInspector, HideInEditorMode]
        public IEntity Entity { get; private set; }
    }
}