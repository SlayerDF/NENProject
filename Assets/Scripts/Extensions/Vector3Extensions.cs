using UnityEngine;

namespace NeonBlack.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Vector3"/>.
    /// TP2 - Tulin Nikita
    /// </summary>
    public static class Vector3Extensions
    {
        public static Vector3 With(this Vector3 vector3, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector3.x, y ?? vector3.y, z ?? vector3.z);
        }

        public static Vector3 Unscale(this Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        }
    }
}
