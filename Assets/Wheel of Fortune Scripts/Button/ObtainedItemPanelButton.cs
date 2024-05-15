using UnityEngine;
using WheelOfFortune.Manager.Button;
using WheelOfFortune.Manager.GameManager;


namespace WheelOfFortune.Buttons
{
    public class ObtainedItemPanelButton : MonoBehaviour, IButton
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameObject _obtainedItemPanel;

        public ButtonType buttonType { get; set; }

        private void Awake()
        {
            buttonType = ButtonType.ObtainedItemPanelButton;
        }

        private void Start()
        {
            gameObject.SetActive(false);
            _obtainedItemPanel.SetActive(false);
        }

        public void ChangeButtonState(bool state)
        {
            gameObject.SetActive(state);
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _gameController.PrepareNewRound();
            }
        }
    }
}

