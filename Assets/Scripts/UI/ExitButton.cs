using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.UI
{
    public class ExitButton : MonoBehaviour
    {

        [SerializeField]
        private GameObject exitWindow;

        public void OnExitButtonClicked()
        {
            exitWindow.SetActive(true);
        }

    }
}