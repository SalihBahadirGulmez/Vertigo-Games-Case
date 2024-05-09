using System.Collections;
using System.Collections.Generic;
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


        

        public void MoveObtainedItemPanel(GameObject cloneRewardImage, GameObject cloneRewardText)
        {

            _obtainedItemPanel.SetActive(true);
            cloneRewardImage.transform.DOMove(_obtainedItemPanel.transform.position, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
            cloneRewardImage.transform.DOScale(cloneRewardImage.transform.localScale * _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration).OnComplete(() =>
            {
                _buttonManager.EnableItemPanelButton();
            });

            cloneRewardText.transform.DOMove(_rewardTextPanelPos.position, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
            cloneRewardText.transform.DOScale(cloneRewardText.transform.localScale * _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);

        }
        public void MoveEndGamePanel(GameObject cloneRewardImage)
        {
            _endGamePanel.SetActive(true);
            cloneRewardImage.transform.DOMove(_endGamePanel.transform.position, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration);
            cloneRewardImage.transform.DOScale(cloneRewardImage.transform.localScale * _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementSpinToObtainedDuration).OnComplete(() =>
            {
                _endGameRestartButton.SetActive(true);
                _endGameLeaveButton.SetActive(true);

            });
        }
        public void MoveAfterRestrart(GameObject cloneRewardImage, GameObject cloneRewardText)
        {
            cloneRewardText.GetComponent<TextMeshProUGUI>().color = new Color(cloneRewardText.GetComponent<TextMeshProUGUI>().color.r, cloneRewardText.GetComponent<TextMeshProUGUI>().color.g, cloneRewardText.GetComponent<TextMeshProUGUI>().color.b, 0f);
            cloneRewardImage.transform.DOScale(new Vector3(0, 0, 0), _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration).OnComplete(() =>
            {
                cloneRewardImage.GetComponent<Image>().color = new Color(cloneRewardImage.GetComponent<Image>().color.r, cloneRewardImage.GetComponent<Image>().color.g, cloneRewardImage.GetComponent<Image>().color.b, 0f);
                _buttonManager.EnableSpinButton();
                _buttonManager.EnableExitButton();
            });
        }

        public void MoveCollectedItemPanel(GameObject cloneRewardImage, GameObject panelReward, GameObject cloneRewardText, GameObject panelRewardText)
        {

            ClampedMovement(cloneRewardImage, panelReward, _minMovePosition.position.y, _maxMovePosition.position.y);
            ClampedMovement(cloneRewardText, panelRewardText, _minMovePosition.position.y, _maxMovePosition.position.y);

            cloneRewardImage.transform.DOScale(cloneRewardImage.transform.localScale / _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration).OnComplete(() =>
            {
                panelReward.GetComponent<Image>().color = new Color(panelReward.GetComponent<Image>().color.r, panelReward.GetComponent<Image>().color.g, panelReward.GetComponent<Image>().color.b, 1f);
                cloneRewardImage.GetComponent<Image>().color = new Color(cloneRewardImage.GetComponent<Image>().color.r, cloneRewardImage.GetComponent<Image>().color.g, cloneRewardImage.GetComponent<Image>().color.b, 0f);
                _buttonManager.EnableSpinButton();
                _buttonManager.EnableExitButton();
            });
            cloneRewardText.transform.DOScale(cloneRewardText.transform.localScale / _rewardsMovementSettings.RewardsSizeScale, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration).OnComplete(() =>
            {
                panelRewardText.GetComponent<TextMeshProUGUI>().color = new Color(panelRewardText.GetComponent<TextMeshProUGUI>().color.r, panelRewardText.GetComponent<TextMeshProUGUI>().color.g, panelRewardText.GetComponent<TextMeshProUGUI>().color.b, 1f);
                cloneRewardText.GetComponent<TextMeshProUGUI>().color = new Color(cloneRewardText.GetComponent<TextMeshProUGUI>().color.r, cloneRewardText.GetComponent<TextMeshProUGUI>().color.g, cloneRewardText.GetComponent<TextMeshProUGUI>().color.b, 0f);
                StartCoroutine(_rewardTextController.UpdateTextValue(panelRewardText.GetComponent<TextMeshProUGUI>(), _gameControllerData.LastCollectedRewardTextOldValue, _gameControllerData.LastCollectedRewardTextNewValue));
            });
        }

        public void ClampedMovement(GameObject obj, GameObject desttination, float min, float max)
        {
            if (min > desttination.transform.position.y)
            {
                obj.transform.DOMove(_minMovePosition.position, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration);
            }
            else if (max < desttination.transform.position.y)
            {
                obj.transform.DOMove(_maxMovePosition.position, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration);
            }
            else
            {
                obj.transform.DOMove(desttination.transform.position, _rewardsMovementSettings.RewardsMovementObtainedToCollectedDuration);
            }
        }

       
        
    }
}
