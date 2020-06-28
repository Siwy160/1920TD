using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.Menu
{
    public class MenuUserInterface : MonoBehaviour, BattleStartListener
    {

        [SerializeField]
        private MenuMap map;

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private BattleData[] battles;

        [SerializeField]
        private BattleWindow battleWindow;

        private void Start()
        {
            battleWindow.BattleStartListener = this;
            battleWindow.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!battleWindow.gameObject.active)
            {
                map.Enabled();
            }
        }

        internal void ShowBattleWidnow(BattleType battleType)
        {
            map.Disable();
            BattleData data = Array.Find(battles, battle => battle.Type == battleType);
            if (data != null)
            {
                battleWindow.Type = data.Type;
                battleWindow.SetHeaderText(data.Name);
                battleWindow.SetDescription(data.Description);
                battleWindow.gameObject.SetActive(true);
            }
        }

        public void OnBattleStarted(BattleType type)
        {
            switch (type)
            {
                case BattleType.PLOCK:
                    {
                        SceneManager.LoadScene("01Plock", LoadSceneMode.Single);
                        break;
                    }
                case BattleType.BORKOWO:
                    {
                        SceneManager.LoadScene("02Borkowo", LoadSceneMode.Single);
                        break;
                    }
                case BattleType.RADZYMIN:
                    {
                        SceneManager.LoadScene("03Radzymin", LoadSceneMode.Single);
                        break;
                    }

            }
        }
    }
}