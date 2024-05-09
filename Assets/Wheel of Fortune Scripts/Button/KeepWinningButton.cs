using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Manager.Button;

namespace WheelOfFortune.Buttons
{
    public class KeepWinningButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ButtonManager _buttonManager;
        [SerializeField] private GameObject _exitGamePanel;

        public void OnPointerDown(PointerEventData eventData)
        {
            _exitGamePanel.SetActive(false);
            _buttonManager.EnableExitButton();
            _buttonManager.EnableSpinButton();
        }
    }
}
