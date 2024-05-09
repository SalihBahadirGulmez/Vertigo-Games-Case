using UnityEngine;
using WheelOfFortune.Buttons;

namespace WheelOfFortune.Manager.Button
{ 
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private SpinButton _spinButton;
        [SerializeField] private ExitButton _exitButton;
        [SerializeField] private ObtainedItemPanelButton _obtainedItemPanelButton;

        public void DisableSpinButton()
        {
            _spinButton.enabled = false;
        }
        public void EnableSpinButton()
        {
            _spinButton.enabled = true;
        }
        public void DisableExitButton()
        {
            _exitButton.enabled = false;
        }
        public void EnableExitButton()
        {
            _exitButton.enabled = true;
        }
        public void DisableItemPanelButton()
        {
            _obtainedItemPanelButton.enabled = false;
        }
        public void EnableItemPanelButton()
        {
            _obtainedItemPanelButton.enabled = true;
        }

    }
}
