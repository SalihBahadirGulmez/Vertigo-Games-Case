using UnityEngine;

namespace WheelOfFortune.Texts.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Text/Reward Text Settings")]

    public class RewardTextSettings : ScriptableObject
    {
        [SerializeField] private int _threshold = 1000;
        [SerializeField] private string _thresholdText = "K";

        [SerializeField] private int _maxIncreaseRate = 5;
        [SerializeField] private int _minIncreaseRate = 1;
        [SerializeField] private int _maxIncreaseRateThreshold = 1000;


        public int Threshold { get { return _threshold; } }
        public string ThresholdText { get { return _thresholdText; } }
        public int MaxIncreaseRate { get { return _maxIncreaseRate; } }
        public int MinIncreaseRate { get { return _minIncreaseRate; } }
        public int MaxIncreaseRateThreshold { get { return _maxIncreaseRateThreshold; } }

        public int IncreaseRateCalculator(int currentValue, int desiredValue)
        {
            return ((desiredValue - currentValue) / MaxIncreaseRateThreshold) * (MaxIncreaseRate - MinIncreaseRate) + MinIncreaseRate;
        }

    }
}