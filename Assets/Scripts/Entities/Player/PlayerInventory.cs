using NeonBlack.Weapons;
using UnityEngine;

namespace NeonBlack.Entities.Player
{
    /// <summary>
    /// Player inventory logic.
    /// TP2 - Savina Elina
    /// </summary>
    public class PlayerInventory : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Weapon[] weapons;

        #endregion


        internal Weapon[] Weapons => weapons;

        // TODO: add weapon selection
        internal Weapon CurrentWeapon => weapons[0];
    }
}
