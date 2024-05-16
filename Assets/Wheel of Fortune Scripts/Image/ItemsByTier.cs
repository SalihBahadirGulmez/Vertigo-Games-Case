using System.Collections.Generic;
using UnityEngine;
using WheelOfFortune.Images.Item;

namespace WheelOfFortune.Images.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Image/Items By Tier")]

    public class ItemsByTier : ScriptableObject
    {
        [SerializeField] private List<ItemUiProperties> _itemsUiProperties;
        [SerializeField] private int _tier;

        public List<ItemUiProperties> ItemsUiProperties { get { return _itemsUiProperties; } set { _itemsUiProperties = value; } }
        public int Tier { get { return _tier; } }
    }


}
