using UnityEngine;

namespace NeonBlack.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Material"/>.
    /// TP2 - Savina Elina
    /// </summary>
    public static class MaterialExtensions
    {
        private const string EmissionName = "_EmissionColor";
        private static readonly int Emission = Shader.PropertyToID(EmissionName);

        public static void SetEmissionColor(this Material material, Color emissionColor)
        {
            if (!material.IsKeywordEnabled(EmissionName))
            {
                material.EnableKeyword(EmissionName);
            }

            material.SetColor(Emission, emissionColor);
        }
    }
}
