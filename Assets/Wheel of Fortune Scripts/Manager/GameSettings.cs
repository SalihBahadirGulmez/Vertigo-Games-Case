using UnityEngine;

namespace WheelOfFortune.Manager.GameManager
{

    [CreateAssetMenu(menuName = "Wheel of Fortune/Manager/Game Settings")]

    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int _superZonePeriod = 30;
        [SerializeField] private int _safeZonePeriod = 5;


        public int SuperZonePeriod { get { return _superZonePeriod; }}
        public int SafeZonePeriod { get { return _safeZonePeriod; } }
        
    }
}
