using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Manager.GameManager;


namespace WheelOfFortune.Buttons
{
    public class RestartButton : MonoBehaviour, IPointerDownHandler
    {

        [SerializeField] private GameController _gameController;
        [SerializeField] private GameObject _endGamePanle;
        [SerializeField] private GameObject _leaveButton;

        public void OnPointerDown(PointerEventData eventData)
        {
            _gameController.PrepareNewGame();

            _endGamePanle.SetActive(false);
            _leaveButton.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }
}
