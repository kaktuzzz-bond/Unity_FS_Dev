using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Extensions
{
    public static class GetRandomItemExtension
    {
        public static T GetRandomItem<T>(this IEnumerable<T> list)
        {
            var result = list.ToArray();
            var index = Random.Range(0, result.Length);
            return result[index];
        }
    }
}