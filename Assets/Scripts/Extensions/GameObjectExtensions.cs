using UnityEngine;

namespace NeonBlack.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="GameObject"/>.
    /// TP2 - Savina Elina.
    /// </summary>
    public static class GameObjectExtensions
    {
        public static bool BelongsTo(this GameObject gameObject, LayerMask layerMask)
        {
            return (layerMask.value & (1 << gameObject.layer)) != 0;
        }

        public static bool IsValidAndEnabled(this GameObject gameObject)
        {
            return gameObject && gameObject.activeInHierarchy;
        }
    }
}
