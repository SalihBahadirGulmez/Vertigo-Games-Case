using UnityEngine;
using WheelOfFortune.Images.Item;

namespace WheelOfFortune.Images.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Image/Reward Image Settings")]

    public class RewardImageSettings : ScriptableObject
    {
        [SerializeField] private float _spinImagesPosX = 0;
        [SerializeField] private float _spinImagesPosY = 273;

        public float SpinImagesPosX { get { return _spinImagesPosX; }  }
        public float SpinImagesPosY { get { return _spinImagesPosY; } }
    }

    public class RewardData
    {
        private ItemUiProperties _itemUiProperties;
        private GameObject _imageGameObject;
        private GameObject _textGameObject;
        private int _quantity;

        public ItemUiProperties ItemUiProperties { get { return _itemUiProperties; } set { _itemUiProperties = value; } }
        public GameObject ImageGameObject { get { return _imageGameObject; } set { _imageGameObject = value; } }
        public GameObject TextGameObject { get { return _textGameObject; } set { _textGameObject = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }

        public RewardData(ItemUiProperties item)
        {
            _itemUiProperties = item;
        }
    }

}