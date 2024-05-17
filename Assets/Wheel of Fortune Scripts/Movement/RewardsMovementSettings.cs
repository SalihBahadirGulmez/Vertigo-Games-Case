using UnityEngine;

namespace WheelOfFortune.Movement.RewardsMovement
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Movement/Rewards Movement Settings")]

    public class RewardsMovementSettings : ScriptableObject
    {
        [SerializeField] private float _rewardsMovementSpinToObtainedDuration = 1f;
        [SerializeField] private float _rewardsMovementObtainedToCollectedDuration = 0.5f;
        [SerializeField] private float _rewardsSizeScale = 5f;

        public float RewardsMovementSpinToObtainedDuration { get { return _rewardsMovementSpinToObtainedDuration; } }
        public float RewardsMovementObtainedToCollectedDuration { get { return _rewardsMovementObtainedToCollectedDuration; } }
        public float RewardsSizeScale { get { return _rewardsSizeScale; } }
    }
}
