namespace NeonBlack.Interfaces
{
    public enum DamageSource
    {
        Normal,
        DeathZone
    }

    /// <summary>
    /// Objects that can take damage should implement this interface.
    /// </summary>
    public interface IEntityHealth
    {
        public void TakeDamage(DamageSource source, float dmg);
    }
}
