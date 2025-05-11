using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Spider
{
    public class SpiderDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode]
        private Spider _spider;
    }
}