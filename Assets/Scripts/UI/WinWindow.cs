namespace Game.Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class WinWindow : MonoBehaviour
    {
        private RetryListener _listener;

        public RetryListener Listener { set => _listener = value; }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnRetryButtonClicked()
        {
            gameObject.SetActive(false);
            _listener.Retry();
        }

        public void OnExitButtonClicked()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}