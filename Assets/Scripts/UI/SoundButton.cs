using Game.Assets.Scripts.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Assets.Scripts.UI
{
    public class SoundButton : MonoBehaviour
    {

        [SerializeField]
        private AudioSource _onClickSound;

        [SerializeField]
        private Sprite _muteSprite;

        [SerializeField]
        private Sprite _soundOnSprite;
        private GameSettings _settings;

        private Button soundButton;
        private void Start()
        {
            GameObject settingsObject = GameObject.FindGameObjectWithTag("Settings");
            _settings = settingsObject.GetComponent<GameSettings>();
            soundButton = gameObject.GetComponent<Button>();
            UpdateAudioListener(false);
        }
        public void OnSoundButtonClicked()
        {
            _settings.SoundMuted = !_settings.SoundMuted;
            UpdateAudioListener(true);
        }

        private void UpdateAudioListener(bool playSound)
        {
            if (soundButton != null)
            {
                if (_onClickSound && playSound)
                {
                    _onClickSound.Play();
                }
                Debug.Log("Sound munted : " + _settings.SoundMuted);
                if (_settings.SoundMuted)
                {
                    AudioListener.volume = 0f;
                    soundButton.image.sprite = _muteSprite;
                }
                else
                {
                    AudioListener.volume = _settings.Volume;
                    soundButton.image.sprite = _soundOnSprite;

                }
            }
        }
    }
}