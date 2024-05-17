using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using WheelOfFortune.Texts.Reward;
using WheelOfFortune.Manager.GameManager;
using WheelOfFortune.Manager.Button;

namespace WheelOfFortune.Movement.RewardsMovement
{
    public class RewardsMovementController : MonoBehaviour
    {
        [SerializeField] private RewardsMovementSettings _rewardsMovementSettings;
        [SerializeField] private RewardTextController _rewardTextController;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private ButtonManager _buttonManager;

        [SerializeField] private GameObject _obtainedItemPanel;
        [SerializeField] private GameObject _endGamePanel;
        [SerializeField] private GameObject _endGameRestartButton;
        [SerializeField] private GameObject _endGameLeaveButton;

        [SerializeField] private Transform _minMovePosition;
        [SerializeField] private Transform _maxMovePosition;

        [SerializeField] private Transform _rewardTextPanelPos;

        public void MoveObtainedItemPanel(Image cloneRewardImage, TextMeshProUGUI cloneRewardText)
        {
            _obtainedItemPanel.SetActive(true);
            cloneRewardImage.transform.DOMove(_obtainedItemPanel.transform.position, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
            cloneRewardImage.transform.DOScale(cloneRewardImage.transform.localScale * _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration).OnComplete(() =>
            {
                _buttonManager.SetButtonStatus(ButtonType.ObtainedItemPanelButton, true);
            });
            cloneRewardText.transform.DOMove(_rewardTextPanelPos.position, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
            cloneRewardText.transform.DOScale(cloneRewardText.transform.localScale * _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
        }
        public void MoveEndGamePanel(Image cloneRewardImage)
        {
            _endGamePanel.SetActive(true);
            cloneRewardImage.transform.DOMove(_endGamePanel.transform.position, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
            cloneRewardImage.transform.DOScale(cloneRewardImage.transform.localScale * _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration).OnComplete(() =>
            {
                _endGameRestartButton.SetActive(true);
                _endGameLeaveButton.SetActive(true);
            });
        }
        public void MoveAfterRestrart(Image cloneRewardImage, TextMeshProUGUI cloneRewardText)
        {
            cloneRewardText.color = new Color(cloneRewardText.color.r, cloneRewardText.color.g, cloneRewardText.color.b, 0f);
            cloneRewardImage.transform.DOScale(new Vector3(0, 0, 0), _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration).OnComplete(() =>
            {
                cloneRewardImage.color = new Color(cloneRewardImage.color.r, cloneRewardImage.color.g, cloneRewardImage.color.b, 0f);
                _buttonManager.SetButtonStatus(ButtonType.SpinButton, true);
                _buttonManager.SetButtonStatus(ButtonType.ExitButton, true);
            });
        }
        public void MoveCollectedItemPanel(Image cloneRewardImage, Image collectedRewardImage, TextMeshProUGUI cloneRewardText, TextMeshProUGUI collectedRewardText)
        {
            ClampedMovement(cloneRewardImage.gameObject, collectedRewardImage.gameObject, _minMovePosition.position.y, _maxMovePosition.position.y);
            ClampedMovement(cloneRewardText.gameObject, collectedRewardText.gameObject, _minMovePosition.position.y, _maxMovePosition.position.y);

            cloneRewardImage.transform.DOScale(cloneRewardImage.transform.localScale / _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration).OnComplete(() =>
            {
                collectedRewardImage.color = new Color(collectedRewardImage.color.r, collectedRewardImage.color.g, collectedRewardImage.color.b, 1f);
                cloneRewardImage.color = new Color(cloneRewardImage.color.r, cloneRewardImage.color.g, cloneRewardImage.color.b, 0f);
                _buttonManager.SetButtonStatus(ButtonType.SpinButton, true);
                _buttonManager.SetButtonStatus(ButtonType.ExitButton, true);
            });
            cloneRewardText.transform.DOScale(cloneRewardText.transform.localScale / _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration).OnComplete(() =>
            {
                collectedRewardText.color = new Color(collectedRewardText.color.r, collectedRewardText.color.g, collectedRewardText.color.b, 1f);
                cloneRewardText.color = new Color(cloneRewardText.color.r, cloneRewardText.color.g, cloneRewardText.color.b, 0f);
                StartCoroutine(_rewardTextController.UpdateTextValue(collectedRewardText, _gameControllerData.LastCollectedRewardTextOldValue, _gameControllerData.LastCollectedRewardTextNewValue));
            });
        }
        public void ClampedMovement(GameObject movingObj, GameObject desttination, float min, float max)
        {
            if (min > desttination.transform.position.y)
            {
                movingObj.transform.DOMove(_minMovePosition.position, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration);
            }
            else if (max < desttination.transform.position.y)
            {
                movingObj.transform.DOMove(_maxMovePosition.position, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration);
            }
            else
            {
                movingObj.transform.DOMove(desttination.transform.position, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration);
            }
        }
    }
}
