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
        }
        private void OnEnable()
        {
            _buttonManager.SetButtonStatus(ButtonType.ExitButton, false);
            _buttonManager.SetButtonStatus(ButtonType.SpinButton, false);
        }
        private void OnDisable()
        {
            _buttonManager.SetButtonStatus(ButtonType.ExitButton, true);
            _buttonManager.SetButtonStatus(ButtonType.SpinButton, true);
        }
    }
}
