using Sirenix.OdinInspector;

namespace Game.App
{
    public class ValueSerializer : GameSerializer<ValueProvider, ValueData>
    {
        [Button]
        protected override ValueData Serialize(ValueProvider service)
        {
            return new ValueData
            {
                value1 = service.Value1,
                value2 = service.Value2
            };
        }

        [Button]
        protected override void Deserialize(ValueProvider service, ValueData data)
        {
            service.Value1 = data.value1;
            service.Value2 = data.value2;
        }
    }
}