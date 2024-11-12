using UnityEngine;

namespace NeonBlack.Interfaces
{
    /// <summary>
    /// Interface for objects that can be distracted.
    /// TP2 - Elina Savina
    /// </summary>
    public interface IDistractible
    {
        void Distract(GameObject distractor, float maxTime);
    }
}
