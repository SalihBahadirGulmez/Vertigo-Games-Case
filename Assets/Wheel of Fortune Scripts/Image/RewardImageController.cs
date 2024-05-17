using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WheelOfFortune.Images.Item;
using WheelOfFortune.Manager.GameManager;
using WheelOfFortune.Manager.Reward;

namespace WheelOfFortune.Images.Reward
{
    public class RewardImageController : MonoBehaviour
    {
        [SerializeField] private RewardImageSettings _rewardImageSettings;
        [SerializeField] private List<ItemUiProperties> _allRewardsUiProperties;
        [SerializeField] internal ItemUiProperties _bombUiProperties;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private RewardManagerSettings _rewardManagerSettings;

        [SerializeField] internal Image[] _spinRewards;

        [SerializeField] internal List<RewardData> _currentSpinRewardsData = new List<RewardData>();

        [SerializeField] private GameObject _collectedItemImagePrefab;
        [SerializeField] private Transform scrollViewContent;

        [SerializeField] internal List<ItemsByTier> _itemsByTier = new List<ItemsByTier>();

        private void Start()
        {
            for (int i = 0; i < _itemsByTier.Count; i++)
            {
                _itemsByTier[i].ItemsUiProperties = _allRewardsUiProperties.FindAll(x => x.Tier == _itemsByTier[i].Tier);
            }
        }

        public void RandomSpinRewardAdjustment()
        {
            int tampBombPosition = Random.Range(0, _spinRewards.Length);
            ItemsByTier tempItems;
            if (_gameControllerData.CurrentRound % _gameSettings.SuperZonePeriod == 0)
            {
                tempItems = _itemsByTier.Find(x => x.Tier == _rewardManagerSettings.ItemTierforSuperZone);
            }
            else if (_gameControllerData.CurrentRound % _gameSettings.SafeZonePeriod == 0)
            {
                tempItems = _itemsByTier.Find(x => x.Tier == _rewardManagerSettings.ItemTierforSafeZone);
            }
            else
            {
                tempItems = _itemsByTier.Find(x => x.Tier == _rewardManagerSettings.ItemTierforNormalZone);
            }
            for (int i = 0; i < _spinRewards.Length; i++)
            {
                if (_gameControllerData.CurrentRound % _gameSettings.SafeZonePeriod != 0 && tampBombPosition == i)
                {
                    ImageSizeAdjustment(_spinRewards[i], _bombUiProperties);
                    SpriteAdjustment(_spinRewards[i], _bombUiProperties);
                    continue;
                }
                int tempRandomItem = Random.Range(0, tempItems.ItemsUiProperties.Count);
                ImageSizeAdjustment(_spinRewards[i], tempItems.ItemsUiProperties[tempRandomItem]);
                SpriteAdjustment(_spinRewards[i], tempItems.ItemsUiProperties[tempRandomItem]);
            }
        }

        public void ImageSizeAdjustment(Image image, ItemUiProperties item)
        {
            image.rectTransform.sizeDelta = new Vector2(item.Width, item.Height);
            image.rectTransform.localScale = new Vector3(item.ScaleX, item.ScaleY, 0);
            image.rectTransform.localPosition = Vector3.up * _rewardImageSettings.SpinImagesPosY;
        }

        public void SpriteAdjustment(Image image, ItemUiProperties item)
        {
            image.sprite = item.SpriteAtlas.GetSprite(item.Name);
            _currentSpinRewardsData.Add(new RewardData(item));
        }

        public GameObject AddNewImageToCollectedItemsPanel(RewardData rewardData)
        {
            GameObject newGameObj = Instantiate(_collectedItemImagePrefab, scrollViewContent);
            Image newImage = newGameObj.GetComponent<Image>();
            ImageSizeAdjustment(newImage, rewardData.ItemUiProperties);

            newImage.sprite = rewardData.ItemUiProperties.SpriteAtlas.GetSprite(rewardData.ItemUiProperties.Name);
            newImage.color = new Color(newImage.color.r, newImage.color.g, newImage.color.b, 0f);
            return newGameObj;
        }

        public void CloneImage(Image clonnedImage, Image baseImage)
        {
            clonnedImage.transform.position = _spinRewards[0].transform.position;
            clonnedImage.rectTransform.sizeDelta = baseImage.rectTransform.sizeDelta;
            clonnedImage.rectTransform.localScale = baseImage.rectTransform.localScale;
            clonnedImage.sprite = baseImage.sprite;
        }
    }
}

