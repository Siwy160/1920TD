using System;
using UnityEngine;

namespace Game.Assets.Scripts.Menu
{
    [Serializable]
    public class CloudsRange
    {
        [SerializeField]
        private int _start;

        [SerializeField]
        private int _end;

        public int Start => _start;
        public int End => _end;
    }
}