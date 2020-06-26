namespace Game.Assets.Scripts.UI
{
    using UnityEngine;

    public class ShopWindow : MonoBehaviour
    {

        [SerializeField]
        private AudioSource _exitButtonClickedSound;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnExitButtonClicked()
        {
            gameObject.SetActive(false);
        }
    }
}