using NeonBlack.Interfaces;
using UnityEngine;

namespace NeonBlack.Interactables
{
    /// <summary>
    /// The death zone is a trigger that kills any entity that enters it.
    /// TP2 - Savina Elina
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        #region Event Functions

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntityHealth entityHealth))
            {
                entityHealth.TakeDamage(DamageSource.DeathZone, float.MaxValue);
            }
        }

        #endregion
    }
}
