using System;
using TMPro;
using UnityEngine;

namespace Game.Assets.Scripts.Menu
{
    public class MoneyController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _moneyPlaceholder;

        private int MAX_MONEY = 9999;
        private int _money;

        public int Money { get => _money; }

        public void AddMoney(int value)
        {
            if (_money + value > MAX_MONEY)
            {
                _money = MAX_MONEY;
            }
            else
            {
                _money += value;
            }
            UpdateMoneyPlaceholder();
        }

        public void SubstractMoney(int value)
        {
            _money -= value;
            UpdateMoneyPlaceholder();
        }

        private void UpdateMoneyPlaceholder()
        {
            _moneyPlaceholder.text = _money.ToString();
        }

        internal void Restart(int moneyAtStart)
        {
            _money = moneyAtStart;
            UpdateMoneyPlaceholder();
        }
    }
}