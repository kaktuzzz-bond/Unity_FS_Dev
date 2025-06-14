using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Game.App
{
    public class ValueSerializer : IGameSerializer
    {
        private readonly ValueProvider _valueProvider;

        private const string Key = "Value";

        public ValueSerializer(ValueProvider valueProvider)
        {
            _valueProvider = valueProvider;
        }

        [Button]
        public void Serialize(IDictionary<string, string> saveState)
        {
            saveState[Key] = _valueProvider.Value.ToString();
        }

        [Button]
        public void Deserialize(IDictionary<string, string> loadState)
        {
            if (loadState.TryGetValue(Key, out var valueText))
            {
                _valueProvider.Value = int.Parse(valueText);
            }
        }
    }
}