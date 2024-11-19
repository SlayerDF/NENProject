using System;

namespace NeonBlack.Interfaces
{
    /// <summary>
    /// Interface for objects that can be activated.
    /// TP2 - Tulin Nikita
    /// </summary>
    public interface IActivatable
    {
        bool IsActivated { get; }
        event Action Activated;
    }
}
