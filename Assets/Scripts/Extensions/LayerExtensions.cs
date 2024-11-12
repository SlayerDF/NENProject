using NeonBlack.Enums;
using UnityEngine;

namespace NeonBlack.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Layer"/>.
    /// TP2 - Tulin Nikita
    /// </summary>
    public static class LayerExtensions
    {
        public static LayerMask ToMask(this Layer layer)
        {
            return 1 << (int)layer;
        }
    }
}
