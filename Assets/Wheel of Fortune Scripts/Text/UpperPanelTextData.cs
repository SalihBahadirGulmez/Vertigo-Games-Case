using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace WheelOfFortune.Texts.UpperPanel
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Text/UpperPanel Text Data")]

    public class UpperPanleTextData : ScriptableObject
    {
        [SerializeField] private int _initialTextCount = 9;
        [SerializeField] private int _maxTextCount = 17;
        [SerializeField] private SpriteAtlas _currentRoundBgSpriteAtlas;
        [SerializeField] internal string[] _spriteAtlasNames = { "ui_card_panel_zone_current", "ui_card_panel_zone_super", "UI_button_orange_standard" };



        public int InitialTextCount { get { return _initialTextCount; } }
        public int MaxTextCount { get { return _maxTextCount; } }
        public SpriteAtlas CurrentRoundBgSpriteAtlas { get { return _currentRoundBgSpriteAtlas; } }



    }
}
