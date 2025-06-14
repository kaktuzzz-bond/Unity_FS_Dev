using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.App
{
    public class ValueSaveLoaderDebug : MonoBehaviour
    {
        [Inject, ShowInInspector, HideInEditorMode]
        private ValueProvider valueProvider;
        
        [Inject, ShowInInspector, HideInEditorMode]
        private GameSaveLoader saveLoader;
    }
}