using System;
using UnityEngine;

namespace Game.Assets.Scripts.Menu
{
    [Serializable]
    public class CloudData
    {
        private GameObject _object;

        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private int _y;

        [SerializeField]
        private CloudsRange _rangeX;

        [SerializeField]
        private CloudsRange _rangeZ;

        public GameObject Object { get => _object; set => _object = value; }
        public int Y { get => _y; set => _y = value; }
        public CloudsRange RangeX { get => _rangeX; set => _rangeX = value; }
        public CloudsRange RangeZ { get => _rangeZ; set => _rangeZ = value; }
        public GameObject Prefab { get => _prefab; set => _prefab = value; }
    }
}