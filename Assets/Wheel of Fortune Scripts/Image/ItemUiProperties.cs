using UnityEngine;
using UnityEngine.U2D;

namespace WheelOfFortune.Images.Item
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Image/Item Ui Properties")]

    public class ItemUiProperties : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private SpriteAtlas _spriteAtlas;
        [SerializeField] private int _tier;
        [SerializeField] private float _width;
        [SerializeField] private float _height;
        [SerializeField] private float _scaleX;
        [SerializeField] private float _scaleY;
        [SerializeField] private ItemType _itemType;

        public string Name { get{ return _name; } }
        public SpriteAtlas SpriteAtlas { get { return _spriteAtlas; } }
        public int Tier { get { return _tier; } }
        public float Width { get { return _width; } }
        public float Height { get { return _height; } }
        public float ScaleX { get { return _scaleX; } }
        public float ScaleY { get { return _scaleY; } }
        public ItemType ItemType { get { return _itemType; } }

    }

    public enum ItemType
    {
        Cash,
        Gold,
        Fragment,
        Chest,
        Weapon,
        Death
    }
}
