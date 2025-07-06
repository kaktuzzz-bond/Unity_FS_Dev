using System.Collections.Generic;
using System.Globalization;
using Game.Gameplay;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Countdown : ComponentSerializer
    {
        ///Variable
        [field: SerializeField]
        public float Current { get; set; }

        ///Const
        [field: SerializeField]
        public float Duration { get; private set; }

        protected override Dictionary<string, string> Serialize()
        {
            return new Dictionary<string, string>()
            {
                { nameof(Current), Current.ToString(CultureInfo.InvariantCulture) }
            };
        }

        protected override void Deserialize(Dictionary<string, string> state)
        {
            Current = float.Parse(state[nameof(Current)]);
        }
    }
}