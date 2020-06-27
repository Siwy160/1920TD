using UnityEngine;

namespace Game
{
    public interface SpotListener
    {
        void OnSpotSelected(TurretSpot spot);
    }
}