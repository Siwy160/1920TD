namespace Game.Assets.Scripts.UI
{
    using System;
    using UnityEngine;

    public class UserInterface : MonoBehaviour
    {
        [SerializeField]
        private GameObject _shopIcon;

        [SerializeField]
        private GameObject _shopWindow;
        private Vector3 _shopIconPosition;

        private void Start()
        {
            _shopIconPosition = _shopIcon.transform.position;
        }

        public void HideShop()
        {
            _shopWindow.SetActive(false);
            _shopIcon.transform.position = new Vector3(0, 100, 0);
        }

        public void ShowShop()
        {
            _shopIcon.transform.position = _shopIconPosition;
        }

        internal void Restart()
        {
            
        }
    }
}