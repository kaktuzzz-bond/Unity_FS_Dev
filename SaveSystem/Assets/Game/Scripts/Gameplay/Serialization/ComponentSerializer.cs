using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class ComponentSerializer : MonoBehaviour
    {
        protected virtual string Key => GetType().Name;

        public void Serialize(IDictionary<string, string> saveState)
        {
            var data = Serialize();
            saveState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> loadState)
        {
            if (!loadState.TryGetValue(Key, out var json))
                return;

            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Deserialize(data);
        }

        protected abstract Dictionary<string, string> Serialize();

        protected abstract void Deserialize(Dictionary<string, string> state);
    }
}