using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Manager.Button;
using WheelOfFortune.Movement.SpinRotate;

namespace WheelOfFortune.Buttons
{
    public class SpinButton : MonoBehaviour, IPointerDownHandler, IButton
    {
        [SerializeField] private SpinRotateController _spinRotateController;

        public ButtonType buttonType{get; set;}

        private void Awake()
        {
            buttonType = ButtonType.SpinButton;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _spinRotateController.RotateSpin();
        }

        public void ChangeButtonState(bool state)
        {
            this.enabled = state;
        }
    }
}

