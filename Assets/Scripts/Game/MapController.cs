namespace GamePlay
{
    using System;
    using UnityEngine;

    public class MapController : MonoBehaviour
    {
        private WaveState _waveState = WaveState.START;

        private MapControllerListener _listener;
        public WaveState WaveState { set => _waveState = value; }
        public MapControllerListener Listener { set => _listener = value; }

        private void Update()
        {
            FindEnemies();
        }

        private void FindEnemies()
        {
            if (_waveState == WaveState.END)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemies.Length == 0)
                {
                    _listener.OnEnemiesDisapear();
                    _waveState = WaveState.START;
                }
            }
        }
    }
}