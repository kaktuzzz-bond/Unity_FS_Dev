using System.Collections.Generic;
using Newtonsoft.Json;
using Zenject;

namespace Game.App
{
    public abstract class GameSerializer<TService, TData> : IGameSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        protected TService _service;

        public void Serialize(IDictionary<string, string> saveState)
        {
            var data = Serialize(_service);
            saveState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> loadState)
        {
            if (!loadState.TryGetValue(Key, out var json))
                return;

            var data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_service, data);
        }

        protected abstract TData Serialize(TService service);

        protected abstract void Deserialize(TService service, TData data);
    }
}