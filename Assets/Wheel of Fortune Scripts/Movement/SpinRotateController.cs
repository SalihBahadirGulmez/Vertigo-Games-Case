using UnityEngine;
using DG.Tweening;
using WheelOfFortune.Manager.Button;
using WheelOfFortune.Manager.GameManager;
using WheelOfFortune.Manager.Reward;

namespace WheelOfFortune.Movement.SpinRotate
{
    public class SpinRotateController : MonoBehaviour
    {
        [SerializeField] private SpinRotateSettings _spinRotateSettings;
        [SerializeField] private RewardManager _rewardManager;
        [SerializeField] private GameController _gameController;
        [SerializeField] private ButtonManager _buttonManager;

        private int _angleBetweenSlots;

        private void Awake()
        {
            _angleBetweenSlots = 360 / _spinRotateSettings.SpinSlotCount;
        }
        public void RotateSpin()
        {
            _buttonManager.SetButtonStatus(ButtonType.SpinButton, false);
            _buttonManager.SetButtonStatus(ButtonType.ExitButton, false);
            int tempRandomRotationAngle = Random.Range(_spinRotateSettings.SpinRotateAngleMin, _spinRotateSettings.SpinRotateAngleMax);
            int tempRewardSlotNum = RewardSlotNumCalculator(ref tempRandomRotationAngle);
            _rewardManager.FindAndCollectReward(tempRewardSlotNum);
            gameObject.transform.DORotate(new Vector3(0, 0, tempRandomRotationAngle), _spinRotateSettings.SpinRotateDuration, RotateMode.LocalAxisAdd).OnComplete(() =>
            {
                _rewardManager._cloneRewardImage.color = new Color(_rewardManager._cloneRewardImage.color.r, _rewardManager._cloneRewardImage.color.g, _rewardManager._cloneRewardImage.color.b, 1f);
                _rewardManager._cloneRewardText.color = new Color(_rewardManager._cloneRewardText.color.r, _rewardManager._cloneRewardText.color.g, _rewardManager._cloneRewardText.color.b, 1f);
                _gameController.OpenRewardPanel();
            });
        }
        public int RewardSlotNumCalculator(ref int rotationAngle)
        {
            rotationAngle -= rotationAngle % _angleBetweenSlots;
            return (rotationAngle / _angleBetweenSlots) % _spinRotateSettings.SpinSlotCount;
        }
    }
}