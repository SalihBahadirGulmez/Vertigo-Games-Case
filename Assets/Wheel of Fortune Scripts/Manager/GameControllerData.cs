using UnityEngine;

namespace WheelOfFortune.Manager.GameManager
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Manager/Game Controller Data")]
    public class GameControllerData : ScriptableObject
    {
        [SerializeField] private int _currentRound = 1;
        [SerializeField] private string _spinResult;
        [SerializeField] private GameObject _lastCollectedRewardImageGameobject;
        [SerializeField] private GameObject _lastCollectedRewardTextGameobject;

        [SerializeField] private int _lastCollectedRewardTextOldValue;
        [SerializeField] private int _lastCollectedRewardTextNewValue;


        public int CurrentRound { get { return _currentRound; } set { _currentRound = value; } }
        public string SpinResult { get { return _spinResult; }set { _spinResult = value; } }
        public GameObject LastCollectedRewardImageGameobject { get { return _lastCollectedRewardImageGameobject; } set { _lastCollectedRewardImageGameobject = value; } }
        public GameObject LastCollectedRewardTextGameobject { get { return _lastCollectedRewardTextGameobject; } set { _lastCollectedRewardTextGameobject = value; } }
        public int LastCollectedRewardTextOldValue { get { return _lastCollectedRewardTextOldValue; } set { _lastCollectedRewardTextOldValue = value; } }
        public int LastCollectedRewardTextNewValue { get { return _lastCollectedRewardTextNewValue; } set { _lastCollectedRewardTextNewValue = value; } }


    }
}
