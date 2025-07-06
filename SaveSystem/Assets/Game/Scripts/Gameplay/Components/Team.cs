using System.Collections.Generic;
using Game.Gameplay;
using Newtonsoft.Json;
using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Team : ComponentSerializer
    {
        ///Variable
        [field: SerializeField]
        public TeamType Type { get; set; }

        protected override Dictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
            {
                
                { nameof(Type), JsonConvert.SerializeObject(Type) },
            };
        }

        protected override void Deserialize(Dictionary<string, string> state)
        {
            Type = JsonConvert.DeserializeObject<TeamType>(state[nameof(Type)]);
        }
    }
}