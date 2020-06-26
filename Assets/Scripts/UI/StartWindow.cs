namespace Game.Assets.Scripts.UI
{
    using UnityEngine;

    public class StartWindow : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _startBattleSound;

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
                if (_startBattleSound != null)
                {
                    _startBattleSound.Play();
                }
                gameObject.SetActive(false);
                _listener.StartBattle();
            }
        }
    }
}