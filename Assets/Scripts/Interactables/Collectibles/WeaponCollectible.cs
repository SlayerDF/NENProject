using NeonBlack.Entities.Player;
using NeonBlack.Weapons;
using UnityEngine;

namespace NeonBlack.Interactables
{
    /// <summary>
    /// Collectible that adds a weapon to the player's inventory.
    /// TP2 - Savina Elina
    /// </summary>
    public class WeaponCollectible : Collectible<PlayerInventory>
    {
        #region Serialized Fields

        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private int ammoCount = 1;

        #endregion

        protected override void OnCollect(PlayerInventory playerInventory)
        {
            playerInventory.AddWeapon(weapon, ammoCount);
        }
    }
}
