using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace WheelOfFortune.Images.Spin
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Image/Spin Indicator")]

    public class SpinIndicator : ScriptableObject
    {
        [SerializeField] private SpriteAtlas _spinIndicatorSprite;

        [SerializeField] private string _spinIndicatorName = "";

        [SerializeField] private int _activeRound = 1;
        [SerializeField] private float _passiveRound = Mathf.Infinity;

        [SerializeField] private float _width = 132.82f;
        [SerializeField] private float _height = 182.242f;
        [SerializeField] private float _scaleX = 1;
        [SerializeField] private float _scaleY = 1;
        [SerializeField] private float _posX = 0;
        [SerializeField] private float _posY = 365;

        public void PrepareSpinBase(int currentRound, Image spinIndicatorImage)
        {
            if (currentRound % _passiveRound != 0 && currentRound % _activeRound == 0)
            {
                if(spinIndicatorImage.sprite.name != _spinIndicatorName)
                {
                    spinIndicatorImage.rectTransform.sizeDelta = new Vector2(_width, _height);
                    spinIndicatorImage.rectTransform.localScale = new Vector3(_scaleX, _scaleY, 0);
                    spinIndicatorImage.rectTransform.localPosition = new Vector3(_posX, _posY, 0);
                    spinIndicatorImage.sprite = _spinIndicatorSprite.GetSprite(_spinIndicatorName);
                }
            }
        }
    }
}