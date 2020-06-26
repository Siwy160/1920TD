using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.UI
{
    public class ExitButton : MonoBehaviour
    {

        public void OnExitButtonClicked()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

    }
}