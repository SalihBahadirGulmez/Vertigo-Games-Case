using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WheelOfFortune.Images.Reward;
using WheelOfFortune.Movement.RewardsMovement;
using WheelOfFortune.Movement.UpperPanel;
using WheelOfFortune.Texts.Reward;
using WheelOfFortune.Texts.UpperPanel;
using WheelOfFortune.Manager.Reward;
using WheelOfFortune.Manager.Button;
using WheelOfFortune.Images.Item;
using WheelOfFortune.Images.Spin;
using UnityEngine.UI;

namespace WheelOfFortune.Manager.GameManager
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private RewardsMovementController _rewardsMovementController;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private RewardManager _rewardManager;
        [SerializeField] private RewardImageController _rewardImageController;
        [SerializeField] private RewardTextController _rewardTextController;
        [SerializeField] private UpperPanelTextController _upperPanelTextController;
        [SerializeField] private UpperPanelMovementController _upperPanelMovementController;
        [SerializeField] private ButtonManager _buttonManager;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private RewardManagerSettings _rewardManagerSettings;


        [SerializeField] private GameObject _obtainedItemPanel;
        [SerializeField] private GameObject _endGamePanle;
        [SerializeField] private Transform _parentSpinBaseTransform;

        [SerializeField] private Image _spinBaseImage;
        [SerializeField] private Image _spinIndicatorImage;
        [SerializeField] private List<SpinBase> _spinBasesSc;
        [SerializeField] private List<SpinIndicator> _spinIndicatorSc;

        [SerializeField] private GameObject _cloneRewardImageGameObject;
        [SerializeField] private GameObject _cloneRewardTextGameObject;

        [SerializeField] private TextMeshProUGUI _nextSafeZoneText;
        [SerializeField] private TextMeshProUGUI _nextSuperZoneText;


        public void Start()
        {
            _gameControllerData.CurrentRound = 1;
            _upperPanelTextController.PrepareUpperPanelForNewGame();
            PrepareSpinBase();
            FindNextZone();
            _rewardImageController.RandomSpinRewardAdjustment();
            _rewardTextController.RewardQuantityCalculator();
        }


        public void PrepareNewRound()
        {
            _buttonManager.SetButtonStatus(ButtonType.ObtainedItemPanelButton, false);
            _obtainedItemPanel.SetActive(false);
            _gameControllerData.CurrentRound += 1;
            _parentSpinBaseTransform.rotation = Quaternion.Euler(0, 0, 0);
            PrepareSpinBase();
            FindNextZone();
            _rewardImageController._currentSpinRewardsData.Clear();
            _rewardsMovementController.MoveCollectedItemPanel(_cloneRewardImageGameObject, _gameControllerData.LastCollectedRewardImageGameobject, _cloneRewardTextGameObject, _gameControllerData.LastCollectedRewardTextGameobject);
            _upperPanelTextController.PrepareUpperPanelForNextRound();
            _upperPanelMovementController.MoveNextRound();
            _rewardImageController.RandomSpinRewardAdjustment();
            _rewardTextController.RewardQuantityCalculator();
        }

        public void PrepareNewGame()
        {
            _endGamePanle.SetActive(false);
            _rewardsMovementController.MoveAfterRestrart(_cloneRewardImageGameObject, _cloneRewardTextGameObject);
            _gameControllerData.CurrentRound = 1;
            _parentSpinBaseTransform.rotation = Quaternion.Euler(0, 0, 0);
            PrepareSpinBase();
            FindNextZone();
            _upperPanelTextController.PrepareUpperPanelForNewGame();
            _rewardImageController._currentSpinRewardsData.Clear();
            DleteCollectedRewards(_rewardManager._collectedRewardsData);
            _rewardImageController.RandomSpinRewardAdjustment();
            _rewardTextController.RewardQuantityCalculator();
        }

        public void DleteCollectedRewards(List<RewardData> collectedRewards)
        {
            for (int i = 0; i < collectedRewards.Count; i++)
            {
                Destroy(collectedRewards[i].ImageGameObject);
                Destroy(collectedRewards[i].TextGameObject);
            }
            collectedRewards.Clear();
        }

        public void OpenRewardPanel()
        {
            if (_gameControllerData.SpinResult == _rewardManagerSettings.WinNewItem)
            {
                _rewardsMovementController.MoveObtainedItemPanel(_cloneRewardImageGameObject, _cloneRewardTextGameObject);
            }
            else if (_gameControllerData.SpinResult == _rewardManagerSettings.WinSameItem)
            { 
                _rewardsMovementController.MoveObtainedItemPanel(_cloneRewardImageGameObject, _cloneRewardTextGameObject);
            }
            else if(_gameControllerData.SpinResult == _rewardManagerSettings.GameOver)
            {
                _rewardsMovementController.MoveEndGamePanel(_cloneRewardImageGameObject);
            }               
        }

        public void PrepareSpinBase()
        {
            _spinBasesSc.ForEach(x => x.PrepareSpinBase(_gameControllerData.CurrentRound, _spinBaseImage));
            _spinIndicatorSc.ForEach(x => x.PrepareSpinBase(_gameControllerData.CurrentRound, _spinIndicatorImage));
        }

        public void FindNextZone()
        {
            if(_gameControllerData.CurrentRound % _gameSettings.SuperZonePeriod == 0) 
            {
                _nextSuperZoneText.text = (_gameControllerData.CurrentRound + _gameSettings.SuperZonePeriod).ToString();
                _nextSafeZoneText.text = (_gameControllerData.CurrentRound + _gameSettings.SafeZonePeriod).ToString();
            }
            else if (_gameControllerData.CurrentRound % _gameSettings.SafeZonePeriod == 0)
            {
                _nextSafeZoneText.text = (_gameControllerData.CurrentRound + _gameSettings.SafeZonePeriod).ToString();
            }
        }

    }
}
