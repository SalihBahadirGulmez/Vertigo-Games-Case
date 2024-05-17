using TMPro;
using UnityEngine;
using UnityEngine.U2D;

namespace WheelOfFortune.Texts.UpperPanel
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Text/UpperPanel Text Settings")]

    public class UpperPanelTextSettings : ScriptableObject
    {
        [SerializeField] private Color _basicColor = Color.white;
        [SerializeField] private Color _currentRoundColor = Color.white;
        [SerializeField] private FontStyles _fontStyle = FontStyles.Bold;
        [SerializeField] private SpriteAtlas _currentRoundBgSpriteAtlas;
        [SerializeField] internal string _backgroundName = "ui_card_panel_zone_current";

        public Color BasicColor { get { return _basicColor; } }
        public Color CurrentRoundColor { get { return _currentRoundColor; } }
        public FontStyles FontStyle { get { return _fontStyle; } }
        public SpriteAtlas CurrentRoundBgSpriteAtlas { get { return _currentRoundBgSpriteAtlas; } }
        public string BackgroundName { get { return _backgroundName; } }
    }
}

