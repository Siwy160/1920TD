using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class PlayerData
    {

        [SerializeField]
        private MoneyData _money;

        [SerializeField]
        private int _startHealth = 20;

        public MoneyData Money { get => _money; }
        public int StartHealth { get => _startHealth; }
    }
}