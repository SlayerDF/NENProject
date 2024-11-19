namespace NeonBlack.Interfaces
{
    /// <summary>
    /// Interface for objects that can be interacted with by the player.
    /// TP2 - Tulin Nikita
    /// </summary>
    public interface IPlayerInteractable
    {
        bool CanBeInteracted { get; }
        void Interact();
    }
}
