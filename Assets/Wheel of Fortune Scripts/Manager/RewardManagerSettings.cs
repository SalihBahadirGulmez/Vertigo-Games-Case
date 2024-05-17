using UnityEngine;

namespace WheelOfFortune.Manager.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Manager/Reward Manager Settings")]
 
    public class RewardManagerSettings : ScriptableObject
    {
        [SerializeField] private int _itemTierforSuperZone = 3;
        [SerializeField] private int _itemTierforSafeZone = 2;
        [SerializeField] private int _itemTierforNormalZone = 1;

        [SerializeField] private string _gameOver = "Game Over";
        [SerializeField] private string _winSameItem = "WinSameItem";
        [SerializeField] private string _winNewItem = "WinNewItem";


        public int ItemTierforSuperZone { get { return _itemTierforSuperZone; } }
        public int ItemTierforSafeZone { get { return _itemTierforSafeZone; } }
        public int ItemTierforNormalZone { get { return _itemTierforNormalZone; } }
        public string GameOver { get { return _gameOver; } }
        public string WinSameItem { get { return _winSameItem; } }
        public string WinNewItem { get { return _winNewItem; } }

    }
}