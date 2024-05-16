using UnityEngine;
using WheelOfFortune.Images.Item;

namespace WheelOfFortune.Texts.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Text/Reward Quanntity Settings")]

    public class RewardQuantitySettings : ScriptableObject
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _minMultiplier = 50;
        [SerializeField] private int _maxMultiplier = 200;
        [SerializeField] private int _maxMultiplierForRound = 20;

        public ItemType ItemType { get { return _itemType; } }
        public int MinMultiplier { get { return _minMultiplier; } }
        public int MaxMultiplier { get { return _maxMultiplier; } }
        public int MaxMultiplierForRound { get { return _maxMultiplierForRound; } }

        public int RandomQuantityCalculator(int currentRound)
        {
            int clampedRound = Mathf.Clamp(currentRound, 0, MaxMultiplierForRound);
            return Random.Range(_minMultiplier * clampedRound, _maxMultiplier * clampedRound);
        }
    }
}
