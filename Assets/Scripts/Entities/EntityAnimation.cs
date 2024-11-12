using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NeonBlack.Entities
{
    /// <summary>
    /// Base class for entity animations.
    /// TP2 - Tulin Nikita
    /// </summary>
    public abstract class EntityAnimation : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Components")]
        [SerializeField]
        protected Animator animator;

        #endregion

        public async UniTask WaitAnimationEnd(int hash, int layer)
        {
            if (!animator.HasState(layer, hash))
            {
                return;
            }

            await UniTask.WaitUntil(
                () => !animator || animator.GetCurrentAnimatorStateInfo(layer).shortNameHash == hash);
            await UniTask.WaitUntil(() =>
                !animator || animator.GetCurrentAnimatorStateInfo(layer).normalizedTime >= 1f);
        }
    }
}
