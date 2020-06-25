using System;
using UnityEngine;

namespace Game.Assets.Scripts.Menu
{
    public class MenuUserInterface : MonoBehaviour
    {

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private BattleData[] battles;

        [SerializeField]
        private BattleWindow battleWindow;

        private void Start()
        {
            battleWindow.gameObject.SetActive(false);
        }

        internal void ShowBattleWidnow(BattleType battleType)
        {
            BattleData data = Array.Find(battles, battle => battle.Type == battleType);
            if (data != null)
            {

                battleWindow.SetHeaderText(data.Name);
                battleWindow.SetDescription(data.Description);
                battleWindow.gameObject.SetActive(true);
            }
        }
    }
}