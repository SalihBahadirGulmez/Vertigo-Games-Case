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
            Vector3 tempDistance = movementDistanceCalculator(_upperPanelRoundInfoPreviousRoundPosition.position, _upperPanelRoundInfoNextRoundPositin.position);
            _upperPanelRoundInfo.DOMoveX(_upperPanelRoundInfo.position.x + tempDistance.x, _upperPanelMovementSettings.NextRoundMovementDuration);
        }

        public void AdjustPanelPosition()
        {
            Vector3 tempDistance = movementDistanceCalculator(_upperPanelRoundInfoNextRoundPositin.position, _upperPanelRoundInfoPreviousRoundPosition.position);
            _upperPanelRoundInfo.position = new Vector3(_upperPanelRoundInfo.position.x + tempDistance.x, _upperPanelRoundInfo.position.y, _upperPanelRoundInfo.position.z);
        }

        public Vector3 movementDistanceCalculator(Vector3 nextPosition, Vector3 previousPosition)
        {
            return (nextPosition - previousPosition) / 2;
        }
    }
}