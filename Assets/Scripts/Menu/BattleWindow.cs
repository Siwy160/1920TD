namespace Game.Assets.Scripts.Menu
{
    using TMPro;
    using UnityEngine;

    public class BattleWindow : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _exitButtonClickedSound;

        [SerializeField]
        private AudioSource _battleStartButtonClickedSound;

        [SerializeField]
        private TMP_Text _header;

        [SerializeField]
        private TMP_Text _description;

        [SerializeField]
        private TMP_Text _buttonTextPlaceholder;

        private BattleType _type;
        private BattleStartListener _battleStartListener;
        public BattleStartListener BattleStartListener { get => _battleStartListener; set => _battleStartListener = value; }
        public BattleType Type { set => _type = value; }

        public void OnCancelButtonClicked()
        {
            if (_exitButtonClickedSound)
            {
                _exitButtonClickedSound.Play();
            }
            gameObject.SetActive(false);
        }

        public void OnButtonClicked()
        {
            if (_battleStartListener != null)
            {
                if (_battleStartButtonClickedSound != null)
                {
                    _battleStartButtonClickedSound.Play();
                }
                _battleStartListener.OnBattleStarted(_type);
            }
        }

        public void SetHeaderText(string text)
        {
            _header.text = text;
        }

        public void SetDescription(string text)
        {
            _description.text = text;
        }

        public void SetButtonText(string text)
        {
            _buttonTextPlaceholder.text = text;
        }
    }
}