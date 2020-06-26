using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class WaveData
    {
        [SerializeField]
        private GameObject[] enemies;

        public GameObject[] Enemies { get => enemies; }
    }
}