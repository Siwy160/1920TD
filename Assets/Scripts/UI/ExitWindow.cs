namespace Game.Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ExitWindow : MonoBehaviour
    {

        [SerializeField]
        private AudioSource _cancelButtonSound;

        [SerializeField]
        private AudioSource _confirmButtonClicked;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnCancelButtonClicked()
        {
            if (_cancelButtonSound != null)
            {
                _cancelButtonSound.Play();
            }
            gameObject.SetActive(false);
        }

        public void OnConfirmButtonClicked()
        {
            if (_confirmButtonClicked)
            {
                _confirmButtonClicked.Play();
            }
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}