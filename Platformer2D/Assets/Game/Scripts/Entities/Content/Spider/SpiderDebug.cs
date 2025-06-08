using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class SpiderDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode]
        private Spider _spider;
    }
}