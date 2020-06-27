namespace Game.Assets.Scripts.UI
{
    using System;
    using System.Collections.Generic;
    using global::GamePlay;
    using global::GamePlay.Data;
    using UnityEngine;
    using UnityEngine.UI;

    public class ShopWindow : MonoBehaviour
    {

        [SerializeField]
        private AudioSource _exitButtonClickedSound;

        [SerializeField]
        private GameObject _content;

        [SerializeField]
        private GameObject _elementPrefab;

        [SerializeField]
        private ScrollRect _scrollRect;

        private ShopWindowListener _listener;

        private TowerData[] _towers;

        private List<TowerListElement> elements = new List<TowerListElement>();

        public ShopWindowListener Listener { set => _listener = value; }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void Initialize(TowerData[] towers, ShopBuyListener listener)
        {
            _towers = towers;
            foreach (TowerData tower in towers)
            {
                TowerListElement element = CreateTowerElement();
                element.SetName(tower.Name);
                element.SetAttack(GetStatisticString(tower.Attak) + "i");
                element.SetAttackSpeed(GetSpeedAttackString(tower.Attak) + "a");
                element.SetRange(GetStatisticString(tower.Attak) + "i");
                element.SetPrice(tower.Price);
                element.Listener = listener;
                element.Data = tower;
                elements.Add(element);
            }
        }

        private string GetStatisticString(StatisticType type)
        {
            switch (type)
            {
                case StatisticType.LOW:
                    {
                        return "Nisk";
                    }
                case StatisticType.NORMAL:
                    {
                        return "Średn";
                    }
                default:
                    {
                        return "Wysok";
                    }
            }
        }

        private string GetSpeedAttackString(StatisticType type)
        {
            switch (type)
            {
                case StatisticType.LOW:
                    {
                        return "Nisk";
                    }
                case StatisticType.NORMAL:
                    {
                        return "Średni";
                    }
                default:
                    {
                        return "Wysok";
                    }
            }
        }

        private TowerListElement CreateTowerElement()
        {
            GameObject towerObject = Instantiate(_elementPrefab);
            towerObject.transform.SetParent(_content.transform, false);
            towerObject.transform.position = _content.transform.position;
            return towerObject.GetComponent<TowerListElement>();
        }

        public void OnExitButtonClicked()
        {
            if (_exitButtonClickedSound != null)
            {
                _exitButtonClickedSound.Play();
            }
            _listener.OnCloseShopWindow();
            gameObject.SetActive(false);
        }

        public void RefreshList(int money)
        {
            elements.ForEach(tower =>
            {
                if (tower.Data.Price <= money)
                {
                    tower.EnableBuyButton();
                }
                else
                {
                    tower.DisableBuyButton();
                }
            });
        }
    }
}