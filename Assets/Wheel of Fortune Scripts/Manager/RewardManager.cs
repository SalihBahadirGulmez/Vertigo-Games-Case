using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WheelOfFortune.Manager.GameManager;
using WheelOfFortune.Images.Reward;
using WheelOfFortune.Texts.Reward;

namespace WheelOfFortune.Manager.Reward
{
    public class RewardManager : MonoBehaviour
    {
        [SerializeField]private RewardManagerSettings _rewardManagerSettings;
        [SerializeField] private RewardImageController _rewardImageController;
        [SerializeField]private RewardTextController _rewardTextController;
        [SerializeField]private GameControllerData _gameControllerData;

        [SerializeField] internal Image _cloneRewardImage;
        [SerializeField] internal TextMeshProUGUI _cloneRewardText;

        [SerializeField] internal List<RewardData> _collectedRewardsData = new List<RewardData>();

        public void FindAndCollectReward(int slotNum)
        {
            _rewardImageController.CloneImage(_cloneRewardImage, _rewardImageController._spinRewards[slotNum]);
            _rewardTextController.CloneText(_cloneRewardText, _rewardTextController._spinRewardTexts[slotNum]);

            RewardData rewardData = _rewardImageController._currentSpinRewardsData[slotNum];
            string rewardName = _rewardImageController._currentSpinRewardsData[slotNum].ItemUiProperties.Name;
            if (_rewardImageController._bombUiProperties.Name == rewardName)
            {
                _gameControllerData.SpinResult = _rewardManagerSettings.GameOver;
                return;
            }
            for (int i = 0; i < _collectedRewardsData.Count; i++)
            {
                if (_collectedRewardsData[i].ItemUiProperties.Name == rewardName)
                {
                    _gameControllerData.SpinResult = _rewardManagerSettings.WinSameItem;

                    _gameControllerData.LastCollectedRewardTextOldValue = _collectedRewardsData[i].Quantity;
                    _collectedRewardsData[i].Quantity += rewardData.Quantity;
                    _gameControllerData.LastCollectedRewardTextNewValue = _collectedRewardsData[i].Quantity;

                    _gameControllerData.LastCollectedRewardImage = _collectedRewardsData[i].ImageGameObject.GetComponent<Image>();
                    _gameControllerData.LastCollectedRewardText = _collectedRewardsData[i].TextGameObject.GetComponent<TextMeshProUGUI>();
                    return;
                }
            }
            _gameControllerData.SpinResult = _rewardManagerSettings.WinNewItem;

            _collectedRewardsData.Add(rewardData);
            _gameControllerData.LastCollectedRewardImage = _rewardImageController.AddNewImageToCollectedItemsPanel(rewardData);
            _collectedRewardsData[_collectedRewardsData.Count - 1].ImageGameObject = _gameControllerData.LastCollectedRewardImage.gameObject;

            _gameControllerData.LastCollectedRewardText = _rewardTextController.AddNewTextToCollectedItemsPanel(rewardData.Quantity);
            _collectedRewardsData[_collectedRewardsData.Count - 1].TextGameObject = _gameControllerData.LastCollectedRewardText.gameObject;

            _gameControllerData.LastCollectedRewardTextOldValue = 0;
            _gameControllerData.LastCollectedRewardTextNewValue = rewardData.Quantity;
        }
    }
}

