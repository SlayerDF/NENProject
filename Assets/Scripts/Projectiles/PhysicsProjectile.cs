﻿using UnityEngine;

namespace NeonBlack.Projectiles
{
    /// <summary>
    /// Base class for projectiles that use physics.
    /// TP2 - Tulin Nikita
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PhysicsProjectile : Projectile
    {
        #region Serialized Fields

        [SerializeField]
        private Rigidbody rigidBody;

        [SerializeField]
        private float initialVelocity = 10f;

        #endregion

        protected Rigidbody RigidBody => rigidBody;

        #region Event Functions

        protected override void OnEnable()
        {
            base.OnEnable();

            rigidBody.velocity = transform.forward * initialVelocity;
        }

        #endregion
    }
}
