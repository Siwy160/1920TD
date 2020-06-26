namespace Game.Assets.Scripts.UI
{
    using UnityEngine;

    public class ShopButton : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _clickButtonSound;

        private ShopButtonListener _listener;

        public ShopButtonListener Listener { set => _listener = value; }

        public void OnButtonClicked()
        {
            if (_clickButtonSound != null)
            {
                _clickButtonSound.Play();
            }

            if (_listener != null)
            {
                _listener.ShowShopWindow();
            }

        }
    }
}