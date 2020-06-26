using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class MoneyData
    {
        [SerializeField]
        private int _moneyAtStart;

        [SerializeField]
        private int _moneyPerSecond;

        public int MoneyAtStart { get => _moneyAtStart; }
        public int MoneyPerSecond { get => _moneyPerSecond; }
    }
}