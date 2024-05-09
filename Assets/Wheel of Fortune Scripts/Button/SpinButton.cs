using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Movement.SpinRotate;

namespace WheelOfFortune.Buttons
{
    public class SpinButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private SpinRotateController _spinRotateController;

        public void OnPointerDown(PointerEventData eventData)
        {
            this.enabled = false;
            _spinRotateController.RotateSpin();
        }
    }
}

