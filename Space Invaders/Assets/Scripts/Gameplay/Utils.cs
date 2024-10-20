using UnityEngine;

namespace Gameplay
{
    public static class Utils
    {
        public static T GetRandomFrom<T>(T[] arr)
        {
            var index = Random.Range(0, arr.Length);
            return arr[index];
        }
    }
}