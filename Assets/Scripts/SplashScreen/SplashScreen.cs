using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.SplashScreen
{
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField]
        private float duration = 3f;

        private float currentDuration = 0f;

        private void Start()
        {
            currentDuration = 0f;
        }
        private void Update()
        {
            currentDuration += Time.deltaTime;

            if (currentDuration >= duration)
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
    }
}