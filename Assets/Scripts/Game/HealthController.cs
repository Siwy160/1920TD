namespace Game.Assets.Scripts.Menu
{
    using System;
    using global::GamePlay;
    using TMPro;
    using UnityEngine;

    public class HealthController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _valuePlaceholder;
        private int _currentHealth = 20;
        private HealthListener _listener;
        public HealthListener Listener { set => _listener = value; }

        public void SetHealth(int value)
        {
            _currentHealth = value;
            UpdateHealthValuePlaceholder();
        }

        private void UpdateHealthValuePlaceholder()
        {
            _valuePlaceholder.text = _currentHealth.ToString();
        }

        public void OnDamageReceived(int damage)
        {
            if (_currentHealth > 0)
            {
                if (_currentHealth - damage <= 0)
                {
                    _currentHealth = 0;
                    _listener.OnPlayerDead();
                }
                else
                {
                    _currentHealth -= damage;
                }
                UpdateHealthValuePlaceholder();
            }
        }

        internal void Restart(int startHealth)
        {
            _currentHealth = startHealth;
            UpdateHealthValuePlaceholder();
        }
    }
}