using System.Collections.Generic;
using Game.Gameplay;
using Newtonsoft.Json;
using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class DestinationPoint : ComponentSerializer
    {
        ///Variable
        [field: SerializeField]
        public Vector3 Value { get; set; }

        protected override Dictionary<string, string> Serialize()
        {
            var serializedVector = new SerializedVector3(Value);

            return new Dictionary<string, string>()
            {
                { nameof(Value), JsonConvert.SerializeObject(serializedVector) }
            };
        }

        protected override void Deserialize(Dictionary<string, string> state)
        {
            Value = JsonConvert.DeserializeObject<SerializedVector3>(state[nameof(Value)]);
        }
    }
}