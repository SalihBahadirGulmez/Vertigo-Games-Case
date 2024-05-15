using UnityEngine;
using UnityEngine.EventSystems;
using WheelOfFortune.Manager.GameManager;


namespace WheelOfFortune.Buttons
{
    public class RestartButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameController _gameController;

        public void OnPointerDown(PointerEventData eventData)
        {
            _gameController.PrepareNewGame();
        }
    }
}
