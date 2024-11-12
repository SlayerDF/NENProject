﻿using UnityEngine;

namespace NeonBlack.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Color"/>.
    /// TP2 - Tulin Nikita
    /// </summary>
    public static class ColorExtensions
    {
        public static Color MoveTowards(this Color currentColor, Color targetColor, float maxDelta)
        {
            return new Color(
                Mathf.MoveTowards(currentColor.r, targetColor.r, maxDelta),
                Mathf.MoveTowards(currentColor.g, targetColor.g, maxDelta),
                Mathf.MoveTowards(currentColor.b, targetColor.b, maxDelta),
                Mathf.MoveTowards(currentColor.a, targetColor.a, maxDelta)
            );
        }
    }
}
