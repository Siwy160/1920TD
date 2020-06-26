using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.UI
{
    public class ExitButton : MonoBehaviour
    {

        [SerializeField]
        private GameObject exitWindow;

        [SerializeField]
        private AudioSource _exitButtonClickedSound;

        public void OnExitButtonClicked()
        {
            if (_exitButtonClickedSound)
            {
                _exitButtonClickedSound.Play();
            }

            exitWindow.SetActive(true);
        }

    }
}