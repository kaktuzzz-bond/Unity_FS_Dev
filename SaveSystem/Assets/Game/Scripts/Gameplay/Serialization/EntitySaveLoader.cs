using System;
using System.Collections.Generic;
using Modules.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public class EntitySaveLoader : SerializedMonoBehaviour
    {
        [SerializeField, ReadOnly, HideInEditorMode]
        private ComponentSerializer[] serializers;

        [ShowInInspector]
        //temporary variable 
        private Dictionary<string, string> _state;

        private void Awake()
        {
            serializers = GetComponents<ComponentSerializer>();
        }


        [Button]
        private void SaveState()
        {
            _state = new Dictionary<string, string>();

            foreach (var serializer in serializers)
            {
                serializer.Serialize(_state);
            }
        }

        [Button]
        private void LoadState()
        {
            foreach (var serializer in serializers)
            {
                serializer.Deserialize(_state);
            }

            _state.Clear();
        }
    }
}