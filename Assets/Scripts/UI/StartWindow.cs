namespace Game.Assets.Scripts.UI
{
    using UnityEngine;

    public class StartWindow : MonoBehaviour
    {

        private StartBattleListener _listener;

        public StartBattleListener Listener { set => _listener = value; }

        private void Start()
        {
            gameObject.SetActive(true);
        }

        public void OnGameStarted()
        {
            if (_listener != null)
            {
                gameObject.SetActive(false);
                _listener.StartBattle();
            }
        }
    }
}