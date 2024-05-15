using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WheelOfFortune.Manager.Button
{ 
    public enum ButtonType
    {
        ExitButton,
        KeepWinningButton,
        LeaveGameButton,
        ObtainedItemPanelButton,
        RestartButton,
        SpinButton
    }
    public interface IButton
    {
        void ChangeButtonState(bool state);
        ButtonType buttonType { get; set; }
    }

    public class ButtonManager : MonoBehaviour
    {

        [SerializeField] private List<IButton> _buttons = new List<IButton>();

        private void Awake()
        {
            _buttons = GetComponentsInChildren<IButton>().ToList();
        }
        public void SetButtonStatus(ButtonType buttonType, bool status)
        {
            IButton desiredButton = _buttons.Find(x => x.buttonType == buttonType);
            desiredButton.ChangeButtonState(status);
        }

    }
}
