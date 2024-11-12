﻿using NeonBlack.Entities.Player;
using NeonBlack.Enums;
using NeonBlack.Utilities;
using UnityEngine;

namespace NeonBlack.Projectiles
{
    /// <summary>
    /// Projectile of simple enemy.
    /// TP2 - Tulin Nikita
    /// </summary>
    public class SimpleEnemyProjectile : Projectile
    {
        #region Serialized Fields

        [SerializeField]
        private float speed = 10f;

        #endregion

        #region Event Functions

        private void Update()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            var layer = (Layer)other.gameObject.layer;

            switch (layer)
            {
                case Layer.Player when other.TryGetComponent(out PlayerController player):
                    player.Kill();
                    break;
            }

            ObjectPoolManager.Despawn(this);
        }

        #endregion
    }
}
