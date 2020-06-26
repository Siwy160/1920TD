using System;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay
{
    public class WavesController
    {
        private WaveData[] _waves;

        public WavesController(WaveData[] waves)
        {
            _waves = waves;
        }

        private int currentWave = -1;

        public WaveData GetWave()
        {
            currentWave += 1;
            return _waves[currentWave];
        }

        public bool AnyWaveLeft()
        {
            return _waves.Length > currentWave + 1;
        }

        internal void Restart()
        {
            currentWave = -1;
        }
    }
}