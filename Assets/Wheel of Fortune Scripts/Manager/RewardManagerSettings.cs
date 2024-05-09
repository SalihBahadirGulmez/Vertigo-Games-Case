using UnityEngine;

namespace WheelOfFortune.Manager.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Manager/Reward Manager Settings")]
 
    public class RewardManagerSettings : ScriptableObject
    {
        [SerializeField]private int _maxTierForSuperZone = 3;
        [SerializeField]private int _maxTierForSafeZone = 2;
        [SerializeField]private int _maxTierForBasicZone = 1;

        public int MaxTierForSuperZone { get { return _maxTierForSuperZone; } }
        public int MaxTierForSafeZone { get { return _maxTierForSafeZone; } }
        public int MaxTierForBasicZone { get { return _maxTierForBasicZone; } }

    }
}