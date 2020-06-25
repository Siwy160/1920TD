using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Assets.Scripts.UI
{
    public class SoundButton : MonoBehaviour
    {

        [SerializeField]
        private Sprite _muteSprite;

        [SerializeField]
        private Sprite _soundOnSprite;

        private bool isMuted = false;

        private Button soundButton;
        private void Start()
        {
            soundButton = gameObject.GetComponent<Button>();
            SwitchButtonMuteOption();
        }
        public void OnSoundButtonClicked()
        {
            SwitchButtonMuteOption();
        }

        private void SwitchButtonMuteOption()
        {
            if (soundButton != null)
            {
                if (isMuted)
                {
                    AudioListener.volume = 0f;
                    soundButton.image.sprite = _muteSprite;
                }
                else
                {
                    AudioListener.volume = 1f;
                    soundButton.image.sprite = _soundOnSprite;

                }
                isMuted = !isMuted;
            }
        }
    }
}