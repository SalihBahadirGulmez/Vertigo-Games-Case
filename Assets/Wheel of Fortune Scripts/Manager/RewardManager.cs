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
        [SerializeField]private RewardImageSettings _rewardImageSettings;
        [SerializeField] private RewardImageController _rewardImageController;
        [SerializeField]private RewardTextController _rewardTextController;
        [SerializeField]private GameControllerData _gameControllerData;

        [SerializeField] internal Image _cloneRewardImage;
        [SerializeField] internal TextMeshProUGUI _cloneRewardText;

        [SerializeField] internal List<RewardData> _collectedRewardsData = new List<RewardData>();
        [SerializeField] internal List<TextMeshProUGUI> _collectedRewardsTexts = new List<TextMeshProUGUI>();


        public void FindAndGetReward(int slotNum)
        {
            _rewardImageController.CloneImage(_cloneRewardImage, _rewardImageController._spinRewards[slotNum]);
            _rewardTextController.CloneText(_cloneRewardText, _rewardTextController._spinRewardTexts[slotNum]);

            if (_rewardImageController._currentSpinRewardsData[slotNum].Name == _rewardImageSettings._bombImage.Name)
            {
                _gameControllerData.SpinResult = "Lose";
                return;
            }
            for (int i = 0; i < _collectedRewardsData.Count; i++)
            {
                if (_collectedRewardsData[i].Name == _rewardImageController._currentSpinRewardsData[slotNum].Name)
                {
                    _gameControllerData.SpinResult = "WinSameItem";
                    _gameControllerData.LastCollectedRewardImageGameobject = _collectedRewardsData[i].ImageGameObject;
                    _gameControllerData.LastCollectedRewardTextOldValue = _collectedRewardsData[i].Quantity;
                    _collectedRewardsData[i].Quantity += _rewardImageController._currentSpinRewardsData[slotNum].Quantity;
                    _gameControllerData.LastCollectedRewardTextNewValue = _collectedRewardsData[i].Quantity;

                    _gameControllerData.LastCollectedRewardTextGameobject = _collectedRewardsData[i].TextGameObject;
                    return;
                }
            }
            _gameControllerData.SpinResult = "WinNewItem";
            _collectedRewardsData.Add(_rewardImageController._currentSpinRewardsData[slotNum]);
            _gameControllerData.LastCollectedRewardImageGameobject = _rewardImageController.AddNewImageToCollectedItemsPanel(_rewardImageController._currentSpinRewardsData[slotNum]);
            _collectedRewardsData[_collectedRewardsData.Count - 1].ImageGameObject = _gameControllerData.LastCollectedRewardImageGameobject;

            _gameControllerData.LastCollectedRewardTextGameobject = _rewardTextController.AddNewTextToCollectedItemsPanel(_rewardImageController._currentSpinRewardsData[slotNum].Quantity);
            _collectedRewardsTexts.Add(_gameControllerData.LastCollectedRewardTextGameobject.GetComponent<TextMeshProUGUI>());
            _collectedRewardsData[_collectedRewardsData.Count - 1].TextGameObject = _gameControllerData.LastCollectedRewardTextGameobject;

            _gameControllerData.LastCollectedRewardTextOldValue = 0;
            _gameControllerData.LastCollectedRewardTextNewValue = _rewardImageController._currentSpinRewardsData[slotNum].Quantity;
        }
    }
}

