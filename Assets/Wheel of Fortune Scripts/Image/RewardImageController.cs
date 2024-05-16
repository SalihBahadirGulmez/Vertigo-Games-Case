using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WheelOfFortune.Images.Item;
using WheelOfFortune.Manager.GameManager;

namespace WheelOfFortune.Images.Reward
{
    public class RewardImageController : MonoBehaviour
    {
        [SerializeField] private RewardImageSettings _rewardImageSettings;
        [SerializeField] private List<ItemUiProperties> _allRewardsUiProperties;
        [SerializeField] internal ItemUiProperties _bombUiProperties;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private GameSettings _gameSettings;

        [SerializeField] internal Image[] _spinRewards;

        [SerializeField] internal List<RewardData> _currentSpinRewardsData = new List<RewardData>();

        [SerializeField] private GameObject _collectedItemImagePrefab;
        [SerializeField] private Transform scrollViewContent;

        [SerializeField] internal List<ItemUiProperties> _rewardsUiPropertiesTier1 = new List<ItemUiProperties>();
        [SerializeField] internal List<ItemUiProperties> _rewardsUiPropertiesTier2 = new List<ItemUiProperties>();
        [SerializeField] internal List<ItemUiProperties> _rewardsUiPropertiesTier3 = new List<ItemUiProperties>();


        private void Start()
        {
            _rewardsUiPropertiesTier1 = _allRewardsUiProperties.FindAll(x => x.Tier == 1);
            _rewardsUiPropertiesTier2 = _allRewardsUiProperties.FindAll(x => x.Tier == 2);
            _rewardsUiPropertiesTier3 = _allRewardsUiProperties.FindAll(x => x.Tier == 3);
        }

        public void RandomSpinRewardAdjustment()
        {
            int tampBombPosition = Random.Range(0, _spinRewards.Length);
            for (int i = 0; i < _spinRewards.Length; i++)
            {
                if (_gameControllerData.CurrentRound % _gameSettings.SafeZonePeriod != 0 && tampBombPosition == i)
                {
                    ImageSizeAdjustment(_spinRewards[i], _bombUiProperties);
                    SpriteAdjustment(_spinRewards[i], _bombUiProperties);
                    continue;
                }
                if (_gameControllerData.CurrentRound % _gameSettings.SuperZonePeriod == 0)
                {
                    int tempRandomSizeNum = Random.Range(0, _rewardsUiPropertiesTier3.Count);
                    ImageSizeAdjustment(_spinRewards[i], _rewardsUiPropertiesTier3[tempRandomSizeNum]);
                    SpriteAdjustment(_spinRewards[i], _rewardsUiPropertiesTier3[tempRandomSizeNum]);
                }
                else if (_gameControllerData.CurrentRound % _gameSettings.SafeZonePeriod == 0)
                {
                    int tempRandomSizeNum = Random.Range(0, _rewardsUiPropertiesTier2.Count);
                    ImageSizeAdjustment(_spinRewards[i], _rewardsUiPropertiesTier2[tempRandomSizeNum]);
                    SpriteAdjustment(_spinRewards[i], _rewardsUiPropertiesTier2[tempRandomSizeNum]);
                }
                else
                {
                    int tempRandomSizeNum = Random.Range(0, _rewardsUiPropertiesTier1.Count);
                    ImageSizeAdjustment(_spinRewards[i], _rewardsUiPropertiesTier1[tempRandomSizeNum]);
                    SpriteAdjustment(_spinRewards[i], _rewardsUiPropertiesTier1[tempRandomSizeNum]);
                }
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

