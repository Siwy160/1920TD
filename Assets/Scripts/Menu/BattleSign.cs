namespace Game.Assets.Scripts.Menu
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class BattleSign : MonoBehaviour
    {

        [SerializeField]
        private Text _namePlaceholder;

        [SerializeField]
        private BattleType _battleType;

        public BattleType BattleType => _battleType;

        private void Start()
        {
            if (_namePlaceholder != null)
            {
                _namePlaceholder.text = GetBattleName();
            }
        }

        private string GetBattleName()
        {
            switch (_battleType)
            {
                case BattleType.RADZYMIN:
                    {
                        return "Radzymin";
                    }
                case BattleType.BORKOWO:
                    {
                        return "Borkowo";
                    }
                default:
                    {
                        return "Płock";
                    }
            }
        }
    }
}