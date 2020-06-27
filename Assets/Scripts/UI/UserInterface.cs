namespace Game.Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UserInterface : MonoBehaviour
    {
        [SerializeField]
        private GameObject _shopIcon;

        [SerializeField]
        private Button[] buttons;

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
            _shopIcon.transform.position = new Vector3(0, 1500, 0);
        }

        public void ShowShop()
        {
            _shopIcon.transform.position = _shopIconPosition;
        }

        internal void Restart()
        {
            ShowShop();
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
        }

        internal void Disable()
        {
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
        }
    }
}