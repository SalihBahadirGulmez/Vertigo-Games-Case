using DG.Tweening;
using UnityEngine;

namespace WheelOfFortune.Movement.UpperPanel
{
    public class UpperPanelMovementController : MonoBehaviour
    {
        [SerializeField] private UpperPanelMovementSettings _upperPanelMovementSettings;

        [SerializeField] private Transform _upperPanelRoundInfo;
        [SerializeField] private Transform _upperPanelRoundInfoNextRoundPositin;
        [SerializeField] private Transform _upperPanelRoundInfoPreviousRoundPosition;


        public void MoveNextRound()
        {
            _upperPanelRoundInfo.DOMoveX(_upperPanelRoundInfo.position.x - (_upperPanelRoundInfoNextRoundPositin.position.x - _upperPanelRoundInfoPreviousRoundPosition.position.x) / 2, _upperPanelMovementSettings.NextRoundMovementDuration);
        }

        public void AdjustPanelPosition()
        {
            _upperPanelRoundInfo.position = new Vector3(_upperPanelRoundInfo.position.x + (_upperPanelRoundInfoNextRoundPositin.position.x - _upperPanelRoundInfoPreviousRoundPosition.position.x) / 2, _upperPanelRoundInfo.position.y, _upperPanelRoundInfo.position.z);
        }

    }
}