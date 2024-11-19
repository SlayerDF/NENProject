using UnityEngine;

namespace NeonBlack.Interactables
{
    public abstract class Collectible : MonoBehaviour
    {
    }

    /// <summary>
    /// Collectible that can be picked up by a specific type of MonoBehaviour.
    /// TP2 - Savina Elina
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class Collectible<T> : Collectible where T : MonoBehaviour
    {
        #region Event Functions

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out T monoBehaviour))
            {
                return;
            }

            OnCollect(monoBehaviour);
            Destroy(gameObject);
        }

        #endregion

        protected abstract void OnCollect(T monoBehaviour);
    }
}
