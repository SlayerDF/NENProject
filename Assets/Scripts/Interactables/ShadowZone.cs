﻿using NeonBlack.Entities.Player;
using NeonBlack.Extensions;
using UnityEngine;

namespace NeonBlack.Interactables
{
    /// <summary>
    /// Shadow zone logic.
    /// TP2 - Tulin Nikita
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class ShadowZone : MonoBehaviour
    {
        private const float ColliderEdgeOffset = 0.5f;

        #region Serialized Fields

        [SerializeField]
        private BoxCollider zoneCollider;

        #endregion

        #region Event Functions

        private void Awake()
        {
            var colliderLossyScaleWithOffset = transform.localScale - ColliderEdgeOffset * 2 * Vector3.one;

            zoneCollider.size = Vector3.Max(Vector3.zero, colliderLossyScaleWithOffset)
                .Unscale(transform.localScale);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                playerController.IsInShadowZone = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                playerController.IsInShadowZone = false;
            }
        }

        #endregion
    }
}
