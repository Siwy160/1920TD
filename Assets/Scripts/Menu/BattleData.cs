using System;
using UnityEngine;

namespace Game.Assets.Scripts.Menu
{
    [Serializable]
    public class BattleData
    {

        [SerializeField]
        private BattleType _type;

        [SerializeField]
        private string _name;

        [TextArea]
        [SerializeField]
        private string _description;

        public string Name => _name;

        public string Description => _description;

        public BattleType Type => _type;
    }
}