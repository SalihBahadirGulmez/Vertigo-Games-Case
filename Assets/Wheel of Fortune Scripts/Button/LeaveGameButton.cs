using UnityEngine;
using UnityEngine.EventSystems;

namespace WheelOfFortune.Buttons
{
    public class LeaveGameButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Application.Quit();
        }
    }
}
