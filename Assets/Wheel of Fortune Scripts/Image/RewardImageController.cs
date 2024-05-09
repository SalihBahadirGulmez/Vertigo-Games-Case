using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WheelOfFortune.Manager.GameManager;
using WheelOfFortune.Manager.Reward;
using WheelOfFortune.Texts.Reward;

namespace WheelOfFortune.Images.Reward
{
    public class RewardImageController : MonoBehaviour
    {
        [SerializeField] private RewardImageSettings _rewardImageSettings;
        [SerializeField] private RewardManagerSettings _rewardManagerSettings;
        [SerializeField] private GameControllerData _gameControllerData;

        [SerializeField] internal Image[] _spinRewards;

        [SerializeField] internal List<RewardData> _currentSpinRewardsData = new List<RewardData>();

        [SerializeField] private GameObject _collectedItemImagePrefab;
        [SerializeField] private Transform scrollViewContent;




        private void Start()
        {
            _rewardImageSettings.SetValues();


        }

        public void SizeAndSpriteAdjustment(Image[] currentSpinRewards)
        {
            int tampBombPosition = Random.Range(0, currentSpinRewards.Length);
            for (int i = 0; i < currentSpinRewards.Length; i++)
            {
                if (_gameControllerData.CurrentRound % 5 != 0 && tampBombPosition == i)
                {
                    currentSpinRewards[i].rectTransform.sizeDelta = new Vector2(_rewardImageSettings._bombImage.Width, _rewardImageSettings._bombImage.Height);
                    currentSpinRewards[i].rectTransform.localPosition = Vector3.up * _rewardImageSettings._bombImage.PosY;
                    currentSpinRewards[i].rectTransform.localScale = new Vector3(_rewardImageSettings._bombImage.ScaleX, _rewardImageSettings._bombImage.ScaleY, 0);

                    currentSpinRewards[i].sprite = _rewardImageSettings._bombImage.SpriteAtlas.GetSprite(_rewardImageSettings._bombImage.Name);

                    _currentSpinRewardsData.Add(_rewardImageSettings._bombImage);
                    continue;
                }
                int tempRandomSizeNum = Random.Range(0, _rewardImageSettings._allSpinSlotImageSizes.Length);

                ImageSizeAdjustment(_spinRewards[i], _rewardImageSettings._allSpinSlotImageSizes[tempRandomSizeNum]);

                if (_gameControllerData.CurrentRound % 30 == 0)
                {
                    RandomSpriteAdjustment(_spinRewards[i], tempRandomSizeNum, _rewardManagerSettings.MaxTierForSuperZone);
                }
                else if (_gameControllerData.CurrentRound % 5 == 0)
                {
                    RandomSpriteAdjustment(_spinRewards[i], tempRandomSizeNum, _rewardManagerSettings.MaxTierForSafeZone);
                }
                else
                {
                    RandomSpriteAdjustment(_spinRewards[i], tempRandomSizeNum, _rewardManagerSettings.MaxTierForBasicZone);
                }
            }
        }

        public void ImageSizeAdjustment(Image image, ImageSize imageSizeObj)
        {
            image.rectTransform.sizeDelta = new Vector2(imageSizeObj.Width, imageSizeObj.Height);
            image.rectTransform.localPosition = Vector3.up * imageSizeObj.PosY;
            image.rectTransform.localScale = new Vector3(imageSizeObj.ScaleX, imageSizeObj.ScaleY, 0);
        }

        public void RandomSpriteAdjustment(Image image, int imageSizeNum, int maxTier)
        {
            int tempRandomTierNum = Random.Range(0, Mathf.Clamp(_rewardImageSettings._allSpriteAtlases[imageSizeNum].Count, 0, maxTier));
            int tempRandomTierNameNum = Random.Range(0, _rewardImageSettings._allSpriteAtlasNames[imageSizeNum][tempRandomTierNum].Count);

            image.sprite = _rewardImageSettings._allSpriteAtlases[imageSizeNum][tempRandomTierNum].GetSprite(_rewardImageSettings._allSpriteAtlasNames[imageSizeNum][tempRandomTierNum][tempRandomTierNameNum]);

            RewardData tempRewardData = new RewardData(_rewardImageSettings._allSpriteAtlasNames[imageSizeNum][tempRandomTierNum][tempRandomTierNameNum], imageSizeNum, tempRandomTierNum, tempRandomTierNameNum, _rewardImageSettings._allImageSizes[imageSizeNum]);
            tempRewardData.SpriteAtlas = _rewardImageSettings._allSpriteAtlases[imageSizeNum][tempRandomTierNum];

            if (imageSizeNum == 0)
            {
                for (int i = 0; i < _rewardImageSettings._squareSpecificSizes.Length; i++)
                {
                    if (_rewardImageSettings._allSpriteAtlasNames[imageSizeNum][tempRandomTierNum][tempRandomTierNameNum] == _rewardImageSettings._squareSpecificNames[i])
                    {
                        image.rectTransform.localScale = new Vector3(_rewardImageSettings._squareSpecificSizes[i], _rewardImageSettings._squareSpecificSizes[i], 0);
                        tempRewardData.ScaleX = image.rectTransform.localScale.x;
                        tempRewardData.ScaleY = image.rectTransform.localScale.y;
                    }
                }
            }
            _currentSpinRewardsData.Add(tempRewardData);
        }

        public GameObject AddNewImageToCollectedItemsPanel(RewardData rewardData)
        {
            GameObject newGameObj = Instantiate(_collectedItemImagePrefab, scrollViewContent);
            Image newImage = newGameObj.GetComponent<Image>();
            ImageSizeAdjustment(newImage, rewardData);

            newImage.sprite = rewardData.SpriteAtlas.GetSprite(rewardData.Name);
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

