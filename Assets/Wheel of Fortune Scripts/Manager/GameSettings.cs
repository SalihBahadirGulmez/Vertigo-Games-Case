using UnityEngine;

namespace WheelOfFortune.Manager.GameManager
{

    [CreateAssetMenu(menuName = "Wheel of Fortune/Manager/Game Settings")]

    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int _superZonePeriod = 30;
        [SerializeField] private int _safeZonePeriod = 5;
        [SerializeField] private int _itemTierforSuperZone = 3;
        [SerializeField] private int _itemTierforSafeZone = 2;
        [SerializeField] private int _itemTierforNormalZone = 1;

        public int SuperZonePeriod { get { return _superZonePeriod; }}
        public int SafeZonePeriod { get { return _safeZonePeriod; } }
        public int ItemTierforSuperZone { get { return _itemTierforSuperZone; } }
        public int ItemTierforSafeZone { get { return _itemTierforSafeZone; } }
        public int ItemTierforNormalZone { get { return _itemTierforNormalZone; } }
    }
}
