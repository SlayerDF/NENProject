namespace NeonBlack.Interfaces
{
    /// <summary>
    /// Objects that can take damage should implement this interface.
    /// </summary>
    public interface IEntityHealth
    {
        public void TakeDamage(float dmg);
    }
}
