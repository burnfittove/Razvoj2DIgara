public interface IDamageable
{
    void TakeDamage(float damage);
    void TakeContactDamage(float damage);
    private void OnDeath() { }
}