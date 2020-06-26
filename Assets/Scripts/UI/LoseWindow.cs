namespace Game.Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LoseWindow : MonoBehaviour
    {
        private RetryListener _listener;

        public RetryListener Listener { set => _listener = value; }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnExitButtonClicked()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        public void OnRetryButtonClicked()
        {
            if (_listener != null)
            {
                gameObject.SetActive(false);
                _listener.Retry();
            }
        }

    }
}