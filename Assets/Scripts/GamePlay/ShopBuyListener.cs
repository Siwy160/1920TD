using GamePlay.Data;

namespace GamePlay
{
    public interface ShopBuyListener
    {
        void OnTowerBuyClicked(TowerData tower);
    }
}