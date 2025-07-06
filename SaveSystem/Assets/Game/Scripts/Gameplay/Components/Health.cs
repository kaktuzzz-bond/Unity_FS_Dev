using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Health : ComponentSerializer
    {
        ///Variable
        [field: SerializeField]
        public int Current { get; set; } = 50;

        ///Const
        [field: SerializeField]
        public int Max { get; private set; } = 100;


        protected override Dictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
            {
                { nameof(Current), Current.ToString() }
            };
        }

        protected override void Deserialize(Dictionary<string, string> state)
        {
            Current = int.Parse(state[nameof(Current)]);
        }
    }
}