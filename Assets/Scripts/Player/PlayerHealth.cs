using SightMaster.Scripts.DamageObject;

public class PlayerHealth : HealthSystem, IPauseBlocker
{
    public bool IsPauseBlocked { get; private set; }

    protected override void Die()
    {
        IsPauseBlocked = true;
        base.Die();
    }
}
