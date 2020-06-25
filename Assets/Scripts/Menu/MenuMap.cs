namespace Game.Assets.Scripts.Menu
{
    using System;
    using UnityEngine;

    public class MenuMap : MonoBehaviour
    {

        [SerializeField]
        private MenuUserInterface _ui;

        private BattleSignListener _currentBattleSelected;

        private bool enabled = true;

        private void Update()
        {
            if (enabled)
            {
                HandleTouchInput();
                HandleMouseInput();
            }
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log("Element hit " + hit.transform.gameObject.name);
                }
            }
        }

        internal void Enabled()
        {
            this.enabled = true;
        }

        internal void Disable()
        {
            this.enabled = false;
        }

        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    BattleSignListener battleSignListener = hit.transform.gameObject.GetComponent<BattleSignListener>();
                    if (battleSignListener != null)
                    {
                        Debug.Log("Battle " + battleSignListener.BattleType + "choosed");
                        if (_currentBattleSelected != null)
                        {
                            _currentBattleSelected.OnBattleDeselected();
                        }
                        battleSignListener.OnBattleSelected();
                        _ui.ShowBattleWidnow(battleSignListener.BattleType);
                        _currentBattleSelected = battleSignListener;
                    }
                }
            }
        }
    }
}