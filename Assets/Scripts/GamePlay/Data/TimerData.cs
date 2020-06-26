using System;
using UnityEngine;

namespace GamePlay
{
    [Serializable]
    public class TimerData
    {
        [SerializeField]
        private float _buildingTime = 10;

        public float BuildingTime { get => _buildingTime; }
    }
}