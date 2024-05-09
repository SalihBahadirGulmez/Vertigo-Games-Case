using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WheelOfFortune.Manager.GameManager;
using TMPro;
using WheelOfFortune.Images.Reward;

namespace WheelOfFortune.Texts.Reward
{
    public class RewardTextController : MonoBehaviour
    {

        [SerializeField] private RewardTextSettings _rewardTextSettings;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private RewardImageController _rewardImageController;

        [SerializeField] internal TextMeshProUGUI[] _spinRewardTexts;


        [SerializeField] private GameObject _collectedItemTextPrefab;
        [SerializeField] private Transform scrollViewContent;

        public void RewardQuantityCalculator()
        {
            for (int i = 0; i < _rewardImageController._currentSpinRewardsData.Count; i++)
            {
                if (_rewardImageController._currentSpinRewardsData[i].Name == "UI_icon_cash")
                {
                    int tempQuantity = Random.Range(_rewardTextSettings.MinMultiplierForCash * Mathf.Clamp(_gameControllerData.CurrentRound, 0, _rewardTextSettings.MaxMultiplierForRound), _rewardTextSettings.MaxMultiplierForCash * Mathf.Clamp(_gameControllerData.CurrentRound, 0, _rewardTextSettings.MaxMultiplierForRound));
                    _rewardImageController._currentSpinRewardsData[i].Quantity = tempQuantity;
                }
                else if (_rewardImageController._currentSpinRewardsData[i].Name == "UI_icon_gold")
                {
                    int tempQuantity = Random.Range(_rewardTextSettings.MinMultiplierForGold * Mathf.Clamp(_gameControllerData.CurrentRound, 0, _rewardTextSettings.MaxMultiplierForRound), _rewardTextSettings.MaxMultiplierForGold * Mathf.Clamp(_gameControllerData.CurrentRound, 0, _rewardTextSettings.MaxMultiplierForRound));
                    _rewardImageController._currentSpinRewardsData[i].Quantity = tempQuantity;
                }
                else if (_rewardImageController._currentSpinRewardsData[i].Name == "ui_card_icon_death")
                {
                    _rewardImageController._currentSpinRewardsData[i].Quantity = 0;
                }
                else if (_rewardImageController._currentSpinRewardsData[i].AtlasSizeNum == 0 && _rewardImageController._currentSpinRewardsData[i].AtlasNameNum !=0)
                {
                    int tempQuantity = Random.Range(_rewardTextSettings.MinValueForFragments, _rewardTextSettings.MaxValueForFragments);
                    _rewardImageController._currentSpinRewardsData[i].Quantity = tempQuantity;
                }
                else
                {
                    _rewardImageController._currentSpinRewardsData[i].Quantity = 1;
                }

                RewardTextQuantityAdjustment(_spinRewardTexts[i], _rewardImageController._currentSpinRewardsData[i].Quantity);         
            }
        }

        public void RewardTextQuantityAdjustment(TextMeshProUGUI text,float value)
        {
            if (value >= 1000)
            {
                text.text = "x" + Mathf.Round(value / 100)/10 + "K";
            }
            else if (value == 0)
            {
                text.text = "";
            }
            else
            {
                text.text = "x" + value;
            }
        }

        public GameObject AddNewTextToCollectedItemsPanel(int quantity)
        {
            GameObject newGameObj = Instantiate(_collectedItemTextPrefab, scrollViewContent);
            TextMeshProUGUI newText = newGameObj.GetComponent<TextMeshProUGUI>();
            newText.color = new Color(newText.color.r, newText.color.g, newText.color.b, 0f);
            RewardTextQuantityAdjustment(newText, quantity);
            return newGameObj;
        }

        public void CloneText(TextMeshProUGUI clonnedText, TextMeshProUGUI baseText)
        {
            clonnedText.transform.position = _spinRewardTexts[0].transform.position;
            clonnedText.text = baseText.text;
        }


        public IEnumerator UpdateTextValue(TextMeshProUGUI text, int currentValue, int lastValue)
        {
            int tempIncreaseAmount = FindIncreaseAmount(currentValue, lastValue);
            while(currentValue < lastValue)
            {
                if(lastValue - currentValue < tempIncreaseAmount) currentValue = lastValue;
                else currentValue += tempIncreaseAmount;
                RewardTextQuantityAdjustment(text, currentValue);
                yield return null;

            }
        }

        public int FindIncreaseAmount(int currentValue, int lastValue)
        {
            if(lastValue - currentValue > 1000)
            {
                return 5;
            }else if(lastValue - currentValue > 500)
            {
                return 2;
            }
            return 1;
        }
    }
}
