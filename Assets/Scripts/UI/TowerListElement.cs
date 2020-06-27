using System;
using GamePlay;
using GamePlay.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Assets.Scripts.UI
{
    public class TowerListElement : MonoBehaviour
    {

        [SerializeField]
        private Image _image;

        [SerializeField]
        private TMP_Text _name;

        [SerializeField]
        private TMP_Text _range;

        [SerializeField]
        private TMP_Text _attack;

        [SerializeField]
        private TMP_Text _attackSpeed;

        [SerializeField]
        private TMP_Text _price;

        [SerializeField]
        private Button _button;

        private TowerData _data;

        private ShopBuyListener _listener;

        public TowerData Data { get => _data; set => _data = value; }

        public ShopBuyListener Listener { set => _listener = value; }
        public AudioSource BuySound { set => _buySound = value; }

        private AudioSource _buySound;

        public void SetAvatar(Sprite avatar)
        {
            _image.sprite = avatar;
        }
        public void SetName(string name)
        {
            _name.text = name;
        }

        public void SetRange(string range)
        {
            _range.text = range;
        }

        public void SetAttack(string attack)
        {
            _attack.text = attack;
        }

        public void SetAttackSpeed(string attackSpeed)
        {
            _attackSpeed.text = attackSpeed;
        }

        public void DisableBuyButton()
        {
            _button.interactable = false;
        }

        public void EnableBuyButton()
        {
            _button.interactable = true;
        }

        internal void SetPrice(int price)
        {
            _price.text = price.ToString();
        }

        public void OnBuyButtonClicked()
        {
            if (_listener != null)
            {
                if (_buySound != null)
                {
                    _buySound.Play();
                }
                _listener.OnTowerBuyClicked(_data);
            }
        }
    }
}