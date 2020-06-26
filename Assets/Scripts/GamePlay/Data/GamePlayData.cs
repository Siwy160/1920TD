using System;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay
{
    [Serializable]
    public class GamePlayData
    {
        [SerializeField]
        private TimerData _timerData;

        [SerializeField]
        private WavesData wavesData;

        public TimerData TimerData { get => _timerData; }

        public WavesData WavesData { get => wavesData; }
    }
}