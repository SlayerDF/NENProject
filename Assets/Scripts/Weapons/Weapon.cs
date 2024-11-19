using NeonBlack.Projectiles;
using UnityEngine;

namespace NeonBlack.Weapons
{
    /// <summary>
    /// Base class for weapons.
    /// TP2 - Savina Elina
    /// </summary>
    public abstract class Weapon : ScriptableObject
    {
        #region Serialized Fields

        [Header("Assets")]
        [SerializeField]
        private Sprite icon;

        [SerializeField]
        private Sprite iconAlpha;

        [SerializeField]
        private Projectile projectilePrefab;

        #endregion

        public Sprite Icon => icon;
        public Sprite IconAlpha => iconAlpha;
        public Projectile ProjectilePrefab => projectilePrefab;

        public abstract void Shoot(Vector3 origin, Vector3 direction);
    }
}
