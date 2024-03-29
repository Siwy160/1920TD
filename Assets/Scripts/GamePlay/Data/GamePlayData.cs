using System;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay
{
    [Serializable]
    public class GamePlayData
    {
        [SerializeField]
        private PlayerData _player;

        [SerializeField]
        private TimerData _timerData;

        [SerializeField]
        private TowersData _towerData;

        [SerializeField]
        private WavesData wavesData;

        public TimerData TimerData { get => _timerData; }

        public WavesData WavesData { get => wavesData; }
        public PlayerData Player { get => _player; }
        public TowersData TowerData { get => _towerData; }
    }
}