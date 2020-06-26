using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class TowersData
    {
        [SerializeField]
        private TowerData[] _towers;
        public TowerData[] Towers { get => _towers; set => _towers = value; }
    }
}