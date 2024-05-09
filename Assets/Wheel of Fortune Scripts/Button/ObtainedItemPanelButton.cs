using UnityEngine;
using WheelOfFortune.Manager.GameManager;


namespace WheelOfFortune.Buttons
{
    public class ObtainedItemPanelButton : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;


        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _gameController.PrepareNewRound();

                this.enabled = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}

