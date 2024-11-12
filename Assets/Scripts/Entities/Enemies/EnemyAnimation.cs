using JetBrains.Annotations;
using NeonBlack.Systems.AudioManagement;
using UnityEngine;

namespace NeonBlack.Entities.Enemies
{
    /// <summary>
    /// Contains enemy animation logic.
    /// TP2 - Tulin Nikita
    /// </summary>
    public class EnemyAnimation : EntityAnimation
    {
        private static readonly int Velocity = Animator.StringToHash("Velocity");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int IsNotifyingBoss = Animator.StringToHash("IsNotifyingBoss");
        public static readonly int Death = Animator.StringToHash("Death");

        private Vector3 lastPosition;

        #region Event Functions

        private void Update()
        {
            if (Time.deltaTime <= 0)
            {
                return;
            }

            var currentPosition = transform.position;
            currentPosition.y = 0f;

            var velocity = Vector3.SqrMagnitude(currentPosition - lastPosition) / Time.deltaTime;

            lastPosition = currentPosition;

            animator.SetFloat(Velocity, velocity);
        }

        #endregion

        public void SetIsAttacking(bool value)
        {
            animator.SetBool(IsAttacking, value);
        }

        public void SetIsNotifyingBoss(bool value)
        {
            animator.SetBool(IsNotifyingBoss, value);
        }

        public void OnDeath()
        {
            animator.SetTrigger(Death);
        }

        [UsedImplicitly]
        private void OnFootsteps()
        {
            AudioManager.Play(AudioManager.FootstepsPrefab, AudioManager.EnemyFootstepsClip, transform.position);
        }
    }
}
