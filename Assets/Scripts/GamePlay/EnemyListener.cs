namespace GamePlay
{
    public interface EnemyListener
    {
        void OnEnemyDead(int money);
        void DoDamage(int damage);
    }
}