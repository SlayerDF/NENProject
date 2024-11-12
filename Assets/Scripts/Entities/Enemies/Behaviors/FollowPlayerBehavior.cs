using NeonBlack.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace NeonBlack.Entities.Enemies.Behaviors
{
    /// <summary>
    /// Behavior that makes an entity follow the player.
    /// TP2 - Tulin Nikita
    /// </summary>
    public class FollowPlayerBehavior : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private NavMeshAgent navAgent;

        [field: SerializeField] public Transform PlayerTransform { get; set; }

        #endregion

        #region Event Functions

        public void FixedUpdate()
        {
            if (!PlayerTransform)
            {
                return;
            }

            navAgent.SetDestination(PlayerTransform.position);

            if (ReachedDestination())
            {
                navAgent.isStopped = true;
                navAgent.velocity = Vector3.zero;
            }
            else
            {
                navAgent.isStopped = false;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying || !isActiveAndEnabled)
            {
                return;
            }

            Handles.color = Color.black;
            Handles.Label(transform.position.With(y: transform.position.y + 3f), navAgent.remainingDistance.ToString());
            Handles.Label(transform.position.With(y: transform.position.y + 2.6f),
                navAgent.stoppingDistance.ToString());
        }
#endif

        #endregion

        private bool ReachedDestination()
        {
            return !float.IsInfinity(navAgent.remainingDistance) &&
                   navAgent.remainingDistance < navAgent.stoppingDistance;
        }
    }
}
