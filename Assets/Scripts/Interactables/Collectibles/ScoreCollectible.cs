using NeonBlack.Entities.Player;
using NeonBlack.Systems.LevelState;
using UnityEngine;

namespace NeonBlack.Interactables
{
    /// <summary>
    /// Collectible that adds score to a player.
    /// TP2 - Savina Elina
    /// </summary>
    public class ScoreCollectible : Collectible<PlayerController>
    {
        #region Serialized Fields

        [SerializeField]
        private float scoreForCollection;

        #endregion

        protected override void OnCollect(PlayerController _)
        {
            LevelState.IncrementScore(scoreForCollection);
            LevelState.NotifyShardCollected();
        }
    }
}
