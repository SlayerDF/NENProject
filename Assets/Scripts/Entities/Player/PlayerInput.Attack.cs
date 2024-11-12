﻿using NeonBlack.Entities.Enemies;
using NeonBlack.Systems.AudioManagement;
using NeonBlack.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NeonBlack.Entities.Player
{
    /// <summary>
    /// Contains the logic related to player attack.
    /// TP2 - Tulin Nikita
    /// </summary>
    public partial class PlayerInput
    {
        #region Serialized Fields

        [Header("Attack")]
        [SerializeField]
        private float attackCooldown = 0.5f;

        [SerializeField]
        private float attackFrame = 0.5f;

        [SerializeField]
        private SubscribableCollider attackCollider;

        #endregion

        private float attackTimer;

        private bool isAttacking;

        private void OnEnableAttack()
        {
            attackCollider.TriggerEnter += OnAttackTriggerEnter;
        }

        private void OnDisableAttack()
        {
            attackCollider.TriggerEnter -= OnAttackTriggerEnter;
        }

        private void OnAttackStarted(InputAction.CallbackContext context)
        {
            isAttacking = true;
        }

        private void OnAttackCanceled(InputAction.CallbackContext context)
        {
            isAttacking = false;
        }

        private void OnShoot(InputAction.CallbackContext context)
        {
            var weapon = inventory.CurrentWeapon;

            if (!weapon || !weapon.ReadyToShoot)
            {
                return;
            }

            weapon.Shoot(Quaternion.Euler(cameraOrbit.x, cameraOrbit.y, 0) * Vector3.forward);
        }

        private static void OnAttackTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EnemyHealth enemyHealth))
            {
                return;
            }

            if (!enemyHealth.Dead)
            {
                AudioManager.Play(AudioManager.HitsPrefab, AudioManager.PlayerHitResultClip, other.transform.position);
            }

            enemyHealth.TakeDamage(1f);
        }

        private void UpdateAttack()
        {
            if (attackTimer > attackFrame)
            {
                attackCollider.enabled = false;
            }

            if (attackTimer < attackCooldown)
            {
                attackTimer += Time.deltaTime;
                return;
            }

            if (!IsGrounded || !isAttacking)
            {
                return;
            }

            attackTimer = 0f;

            playerAnimation.OnAttack();
            attackCollider.enabled = true;
        }
    }
}
