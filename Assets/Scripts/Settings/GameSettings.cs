using UnityEngine;

namespace Game.Assets.Scripts.Settings
{
    public class GameSettings : MonoBehaviour
    {
        [Range(0, 1f)]
        [SerializeField]
        private float volume = 1f;

        [SerializeField]
        private bool _soundMuted;

        public bool SoundMuted { get => _soundMuted; set => _soundMuted = value; }
        public float Volume { get => volume; }

        private static bool created = false;

        private void Update()
        {
            if (!_soundMuted)
            {
                AudioListener.volume = volume;
            }
        }

        private void Awake()
        {
            if (!created)
            {
                Debug.Log(_soundMuted);
                DontDestroyOnLoad(this.gameObject);
                created = true;
            }
        }
    }
}