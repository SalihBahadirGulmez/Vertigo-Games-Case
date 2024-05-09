using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Manager.Button;

namespace WheelOfFortune.Buttons
{
    public class ExitButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ButtonManager _buttonManager;
        [SerializeField] private GameObject _exitGamePanel;

        public void OnPointerDown(PointerEventData eventData)
        {
            _buttonManager.DisableExitButton();
            _buttonManager.DisableSpinButton();
            _exitGamePanel.SetActive(true);
        }
    }
}
