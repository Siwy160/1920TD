namespace Game.Assets.Scripts.Menu
{
    using UnityEngine;

    public class MenuMap : MonoBehaviour
    {

        private BattleSignListener _currentBattleSelected;

        private void Update()
        {
            HandleTouchInput();
            HandleMouseInput();
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
                        _currentBattleSelected = battleSignListener;
                    }
                }
            }
        }
    }
}