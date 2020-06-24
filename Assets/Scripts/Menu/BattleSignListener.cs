using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Assets.Scripts.Menu
{
    public class BattleSignListener : MonoBehaviour
    {

        [SerializeField]
        private Text battlePlaceholder;

        [SerializeField]
        private BattleSign _battleSign;

        public BattleType BattleType => _battleSign.BattleType;

        public BattleSign BattleSign => _battleSign;

        private Renderer renderer;

        private void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        internal void OnBattleDeselected()
        {
            renderer.material.SetColor("_BaseColor", Color.white);
            battlePlaceholder.color = Color.white;
        }

        internal void OnBattleSelected()
        {
            renderer.material.SetColor("_BaseColor", Color.yellow);
            battlePlaceholder.color = Color.yellow;
        }
    }
}