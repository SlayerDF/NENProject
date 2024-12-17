using System;
using NeonBlack.Interfaces;
using UnityEngine;

namespace NeonBlack.Entities.Enemies
{
    /// <summary>
    /// Contains enemy health logic.
    /// TP2 - Tulin Nikita
    /// </summary>
    public class EnemyHealth : MonoBehaviour, IEntityHealth
    {
        #region Serialized Fields

        [Header("Properties")]
        [SerializeField]
        private float health = 1f;

        [Header("Visuals")]
        [SerializeField]
        private ParticleSystem bloodParticles;

        #endregion

        public bool Dead { get; private set; }

        public bool Invincible { get; set; }

        #region IEntityHealth Members

        public void TakeDamage(DamageSource _, float damage)
        {
            if (Invincible)
            {
                return;
            }

            health -= damage;

            if (health > 0 || Dead)
            {
                return;
            }

            Dead = true;

            if (bloodParticles)
            {
                bloodParticles.Play();
            }

            Death?.Invoke();
        }

        #endregion

        public void Kill()
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        public event Action Death;
    }
}
