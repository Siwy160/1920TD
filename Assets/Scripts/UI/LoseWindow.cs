namespace Game.Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LoseWindow : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _exitSound;

        [SerializeField]
        private AudioSource _retrySound;

        private RetryListener _listener;

        public RetryListener Listener { set => _listener = value; }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnExitButtonClicked()
        {
            if (_exitSound != null)
            {
                _exitSound.Play();
            }

            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        public void OnRetryButtonClicked()
        {
            if (_listener != null)
            {
                gameObject.SetActive(false);
                if (_retrySound != null)
                {
                    _retrySound.Play();
                }
                _listener.Retry();
            }
        }
    }
}