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
            if (_exitButtonClickedSound != null)
            {
                _exitButtonClickedSound.Play();
            }
            
            gameObject.SetActive(false);
        }
    }
}