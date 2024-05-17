using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace WheelOfFortune.Images.Spin
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Image/Spin Base")]

    public class SpinBase : ScriptableObject
    {
        [SerializeField] private SpriteAtlas _spinBaseSprite;

        [SerializeField] private string _spinBaseName = "";

        [SerializeField] private int _activeRound = 1;
        [SerializeField] private float _passiveRound = Mathf.Infinity;

        [SerializeField] private float _width = 900;
        [SerializeField] private float _height = 900;
        [SerializeField] private float _scaleX = 1;
        [SerializeField] private float _scaleY = 1;
        [SerializeField] private float _posX;
        [SerializeField] private float _posY;

        public void PrepareSpinBase(int currentRound, Image spinBaseImage)
        {
            if (currentRound % _passiveRound != 0 && currentRound % _activeRound == 0)
            {
                if (spinBaseImage.sprite.name != _spinBaseName)
                {
                    spinBaseImage.rectTransform.sizeDelta = new Vector2(_width, _height);
                    spinBaseImage.rectTransform.localScale = new Vector3(_scaleX, _scaleY, 0);
                    spinBaseImage.rectTransform.localPosition = new Vector3(_posX, _posY, 0);
                    spinBaseImage.sprite = _spinBaseSprite.GetSprite(_spinBaseName);
                }
            }
        }
    }
}