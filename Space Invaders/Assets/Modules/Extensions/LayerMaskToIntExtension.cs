using UnityEngine;

namespace Modules.Extensions
{
    public static class LayerMaskToIntExtension
    {
        public static int LayerMaskToInt(this LayerMask layerMask)
        {
            var log = Mathf.Log(layerMask.value, 2);
            return Mathf.RoundToInt(log);
        }
    }
}