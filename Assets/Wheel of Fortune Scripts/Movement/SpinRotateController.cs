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

        public void RotateSpin()
        {
            _buttonManager.SetButtonStatus(ButtonType.SpinButton, false);
            _buttonManager.SetButtonStatus(ButtonType.ExitButton, false);
            int tempRandomRotation = Random.Range(_spinRotateSettings.SpinRotateAngleMin, _spinRotateSettings.SpinRotateAngleMax);
            tempRandomRotation -= tempRandomRotation % 45;
            int tempRewardSlotNum = (tempRandomRotation / 45) % 8;
            _rewardManager.FindAndGetReward(tempRewardSlotNum);
            gameObject.transform.DORotate(new Vector3(0, 0, tempRandomRotation), _spinRotateSettings.SpinRotateDuration, RotateMode.LocalAxisAdd).OnComplete(StartAfterRotation);
        }

        public void StartAfterRotation()
        {
            _rewardManager._cloneRewardImage.color = new Color(_rewardManager._cloneRewardImage.color.r, _rewardManager._cloneRewardImage.color.g, _rewardManager._cloneRewardImage.color.b, 1f);
            _rewardManager._cloneRewardText.color = new Color(_rewardManager._cloneRewardText.color.r, _rewardManager._cloneRewardText.color.g, _rewardManager._cloneRewardText.color.b, 1f);
            _gameController.OpenRewardPanel();
        }
    }
}