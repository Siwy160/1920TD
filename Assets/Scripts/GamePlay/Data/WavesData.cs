using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class WavesData
    {
        [SerializeField]
        private WaveData[] waves;

        public WaveData[] Waves { get => waves; }
    }
}