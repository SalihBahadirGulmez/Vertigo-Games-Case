using UnityEngine;

namespace WheelOfFortune.Texts.UpperPanel
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Text/UpperPanel Settings")]

    public class UpperPanelSettings : ScriptableObject
    {
        [SerializeField] private int _initialTextCount = 9;
        [SerializeField] private int _maxTextCount = 17;

        public int InitialTextCount { get { return _initialTextCount; } }
        public int MaxTextCount { get { return _maxTextCount; } }
    }
}
