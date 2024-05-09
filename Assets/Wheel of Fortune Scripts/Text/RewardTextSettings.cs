using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WheelOfFortune.Texts.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Text/Reward Text Settings")]

    public class RewardTextSettings : ScriptableObject
    {
        [SerializeField] private int _minMultiplierForCash = 50;
        [SerializeField] private int _maxMultiplierForCash = 200;
        [SerializeField] private int _minMultiplierForGold = 1;
        [SerializeField] private int _maxMultiplierForGold = 4;
        [SerializeField] private int _minValueForFragments = 5;
        [SerializeField] private int _maxValueForFragments = 10;
        [SerializeField] private int _maxMultiplierForRound = 20;



        public int MinMultiplierForCash { get { return _minMultiplierForCash; } }
        public int MaxMultiplierForCash { get { return _maxMultiplierForCash; } }
        public int MinMultiplierForGold { get { return _minMultiplierForGold; } }
        public int MaxMultiplierForGold { get { return _maxMultiplierForGold; } }
        public int MinValueForFragments { get { return _minValueForFragments; } }
        public int MaxValueForFragments { get { return _maxValueForFragments; } }
        public int MaxMultiplierForRound { get { return _maxMultiplierForRound; } }


    }
}
