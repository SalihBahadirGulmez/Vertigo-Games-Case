using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Manager.Button;

namespace WheelOfFortune.Buttons
{
    public class ExitButton : MonoBehaviour, IPointerDownHandler, IButton
    {
        [SerializeField] private GameObject _exitGamePanel;

        public ButtonType buttonType { get ; set ; }
        private void Awake()
        {
            buttonType = ButtonType.ExitButton;
        }

        public void ChangeButtonState(bool state)
        {
            this.enabled = state;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _exitGamePanel.SetActive(true);
        }
    }
}
