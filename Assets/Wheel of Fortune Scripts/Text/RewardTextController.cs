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

        [SerializeField] private List<RewardQuantitySettings> _rewardQuantitySettings;
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
                RewardData tempData = _rewardImageController._currentSpinRewardsData[i];
                tempData.Quantity = _rewardQuantitySettings.Find(x => x.ItemType == tempData.ItemUiProperties.ItemType).RandomQuantityCalculator(_gameControllerData.CurrentRound);

                RewardTextQuantityAdjustment(_spinRewardTexts[i], tempData.Quantity);         
            }
        }

        public void RewardTextQuantityAdjustment(TextMeshProUGUI text,float value)
        {
            if (value >= _rewardTextSettings.Threshold)
            {
                text.text = "x" + Mathf.Round(value / (_rewardTextSettings.Threshold / 10)) /10 + _rewardTextSettings.ThresholdText;
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


        public IEnumerator UpdateTextValue(TextMeshProUGUI text, int currentValue, int desiredValue)
        {
            int tempIncreaseAmount = FindIncreaseAmount(currentValue, desiredValue);
            while(currentValue < desiredValue)
            {
                if(desiredValue - currentValue < tempIncreaseAmount) currentValue = desiredValue;
                else currentValue += tempIncreaseAmount;
                RewardTextQuantityAdjustment(text, currentValue);
                yield return null;
            }
        }

        public int FindIncreaseAmount(int currentValue, int desiredValue)
        {
            if(desiredValue - currentValue > _rewardTextSettings.MaxIncreaseRateThreshold)
            {
                return _rewardTextSettings.MaxIncreaseRate;
            }else
            {
                return _rewardTextSettings.IncreaseRateCalculator(currentValue, desiredValue);
            }
        }
    }
}
