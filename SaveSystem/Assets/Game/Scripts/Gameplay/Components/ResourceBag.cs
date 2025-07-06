using System.Collections.Generic;
using Game.Gameplay;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class ResourceBag : ComponentSerializer
    {
        ///Variable
        [field: SerializeField]
        public ResourceType Type { get; set; }
        
        ///Variable
        [field: SerializeField]
        public int Current { get; set; }
        
        ///Const
        [field: SerializeField]
        public int Capacity { get; set; }

        protected override Dictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
            {
                
                { nameof(Type), JsonConvert.SerializeObject(Type) },
                { nameof(Current), Current.ToString() }
            };
        }

        protected override void Deserialize(Dictionary<string, string> state)
        {
            Type = JsonConvert.DeserializeObject<ResourceType>(state[nameof(Type)]);
            Current = int.Parse(state[nameof(Current)]);
        }
    }
}