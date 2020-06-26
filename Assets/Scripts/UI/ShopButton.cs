namespace Game.Assets.Scripts.UI
{
    using UnityEngine;

    public class ShopButton : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _clickButtonSound;

        [SerializeField]
        private GameObject shopWindow;

        public void OnButtonClicked()
        {
            if (_clickButtonSound != null)
            {
                _clickButtonSound.Play();
            }

            if (shopWindow != null)
            {
                shopWindow.SetActive(true);
            }

        }
    }
}