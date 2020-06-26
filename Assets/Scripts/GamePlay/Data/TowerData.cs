using System;
using UnityEngine;

namespace GamePlay.Data
{
    [Serializable]
    public class TowerData
    {
        [SerializeField]
        private Sprite image;

        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private String name;

        [SerializeField]
        private int _price;

        [SerializeField]
        private StatisticType _attak;

        [SerializeField]
        private StatisticType _attakSpeed;

        [SerializeField]
        private StatisticType _range;

        public Sprite Image { get => image; }

        public GameObject Prefab { get => _prefab; }
        public string Name { get => name; }
        public int Price { get => _price; }
        public StatisticType Attak { get => _attak; }
        public StatisticType AttakSpeed { get => _attakSpeed; }
        public StatisticType Range { get => _range; }
    }
}