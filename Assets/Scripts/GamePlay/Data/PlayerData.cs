using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class PlayerData
    {

        [SerializeField]
        MoneyData _money;

        public MoneyData Money { get => _money; set => _money = value; }
    }
}