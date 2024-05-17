using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortune.Manager.GameManager
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Manager/Game Controller Data")]
    public class GameControllerData : ScriptableObject
    {
        [SerializeField] private int _currentRound = 1;
        [SerializeField] private string _spinResult;
        [SerializeField] private Image _lastCollectedRewardImage;
        [SerializeField] private TextMeshProUGUI _lastCollectedRewardText;

        [SerializeField] private int _lastCollectedRewardTextOldValue;
        [SerializeField] private int _lastCollectedRewardTextNewValue;


        public int CurrentRound { get { return _currentRound; } set { _currentRound = value; } }
        public string SpinResult { get { return _spinResult; }set { _spinResult = value; } }
        public Image LastCollectedRewardImage { get { return _lastCollectedRewardImage; } set { _lastCollectedRewardImage = value; } }
        public TextMeshProUGUI LastCollectedRewardText { get { return _lastCollectedRewardText; } set { _lastCollectedRewardText = value; } }
        public int LastCollectedRewardTextOldValue { get { return _lastCollectedRewardTextOldValue; } set { _lastCollectedRewardTextOldValue = value; } }
        public int LastCollectedRewardTextNewValue { get { return _lastCollectedRewardTextNewValue; } set { _lastCollectedRewardTextNewValue = value; } }


    }
}
