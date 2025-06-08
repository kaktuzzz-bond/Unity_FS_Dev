using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class PlatformDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode]
        private Platform _platform;
    }
}