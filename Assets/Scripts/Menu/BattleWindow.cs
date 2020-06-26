namespace Game.Assets.Scripts.Menu
{
    using TMPro;
    using UnityEngine;

    public class BattleWindow : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _header;

        [SerializeField]
        private TMP_Text _description;

        [SerializeField]
        private TMP_Text _buttonTextPlaceholder;

        [SerializeField]
        private string _battleName;

        [SerializeField]
        private string _battleDescription;

        [SerializeField]
        private string _buttonText;

        private BattleType _type;
        private BattleStartListener _battleStartListener;
        public BattleStartListener BattleStartListener { get => _battleStartListener; set => _battleStartListener = value; }
        public BattleType Type { set => _type = value; }

        public void OnCancelButtonClicked()
        {
            gameObject.SetActive(false);
        }

        public void OnButtonClicked()
        {
            if (_battleStartListener != null)
            {
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