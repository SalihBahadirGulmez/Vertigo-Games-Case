using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WheelOfFortune.Manager.GameManager;
using UnityEngine.UI;
using WheelOfFortune.Movement.UpperPanel;


namespace WheelOfFortune.Texts.UpperPanel
{
    public class UpperPanelTextController : MonoBehaviour
    {
        [SerializeField] private UpperPanelMovementController _upperPanelMovementController;

        [SerializeField] private UpperPanelSettings _upperPanelSettings;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private List<TextMeshProUGUI> _upperPanelTexts = new List<TextMeshProUGUI>();

        [SerializeField] private GameObject _upperPanelTextPrefab;
        [SerializeField] private Transform _upperPanelRoundInfo;
        [SerializeField] private Transform _upperPanelPosition;
        [SerializeField] private Image _currentRoundBgImage;

        [SerializeField] private UpperPanelTextSettings _basicZoneTextSettings;
        [SerializeField] private UpperPanelTextSettings _safeZoneTextSettings;
        [SerializeField] private UpperPanelTextSettings _superZoneTextSettings;

        public void PrepareUpperPanelForNextRound()
        {

            if (_upperPanelTexts.Count >= _upperPanelSettings.MaxTextCount)
            {
                Destroy(_upperPanelTexts[_upperPanelTexts.Count - _upperPanelSettings.MaxTextCount]);
                _upperPanelMovementController.AdjustPanelPosition();
            }
            _upperPanelTexts.Add(AddNewTextToUpperPanel());
            AdjustCurrentRoundTextAndImage();
        }

        public TextMeshProUGUI AddNewTextToUpperPanel()
        {
            GameObject newGameObj = Instantiate(_upperPanelTextPrefab, _upperPanelRoundInfo);
            TextMeshProUGUI tempText = newGameObj.GetComponent<TextMeshProUGUI>();
            UpperPanelTextAdjustmen(tempText);
            return tempText;
        }

        public void UpperPanelTextAdjustmen(TextMeshProUGUI text)
        {
            if ((_upperPanelTexts.Count + 1) % _gameSettings.SuperZonePeriod == 0)
            {
                text.color = _superZoneTextSettings.BasicColor;
                text.fontStyle = _superZoneTextSettings.FontStyle;
            }
            else if ((_upperPanelTexts.Count + 1) % _gameSettings.SafeZonePeriod == 0)
            {
                text.color = _safeZoneTextSettings.BasicColor;
                text.fontStyle = _safeZoneTextSettings.FontStyle;
            }
            else
            {
                text.color = _basicZoneTextSettings.BasicColor;
            }
            text.text = (_upperPanelTexts.Count + 1).ToString();
        }

        public void AdjustCurrentRoundTextAndImage()
        {
            if (_gameControllerData.CurrentRound % _gameSettings.SuperZonePeriod == 0)
            {
                _upperPanelTexts[_gameControllerData.CurrentRound - 1].color = _superZoneTextSettings.CurrentRoundColor;
                _currentRoundBgImage.sprite = _superZoneTextSettings.CurrentRoundBgSpriteAtlas.GetSprite(_superZoneTextSettings.BackgroundName);
            }
            else if (_gameControllerData.CurrentRound % _gameSettings.SafeZonePeriod == 0)
            {
                _upperPanelTexts[_gameControllerData.CurrentRound - 1].color = _safeZoneTextSettings.CurrentRoundColor;
                _currentRoundBgImage.sprite = _safeZoneTextSettings.CurrentRoundBgSpriteAtlas.GetSprite(_safeZoneTextSettings.BackgroundName);
            }
            else
            {
                _upperPanelTexts[_gameControllerData.CurrentRound - 1].color = _basicZoneTextSettings.CurrentRoundColor;
                _currentRoundBgImage.sprite = _basicZoneTextSettings.CurrentRoundBgSpriteAtlas.GetSprite(_basicZoneTextSettings.BackgroundName);
            }
            
            if(_gameControllerData.CurrentRound - 1 > 0 && (_gameControllerData.CurrentRound - 1) % _gameSettings.SuperZonePeriod == 0)
            {
                _upperPanelTexts[_gameControllerData.CurrentRound - 2].color = _superZoneTextSettings.BasicColor;
            }
            else if (_gameControllerData.CurrentRound - 1 > 0 && (_gameControllerData.CurrentRound - 1) % _gameSettings.SafeZonePeriod == 0)
            {
                _upperPanelTexts[_gameControllerData.CurrentRound - 2].color = _safeZoneTextSettings.BasicColor;
            }
        }

        public void PrepareUpperPanelForNewGame()
        {
            for (int i = 0; i < _upperPanelTexts.Count; i++)
            {
                Destroy(_upperPanelTexts[i].gameObject);
            }
            _upperPanelTexts.Clear();

            _upperPanelRoundInfo.position = _upperPanelPosition.position;

            for (int i = 0; i < _upperPanelSettings.InitialTextCount; i++)
            {
                _upperPanelTexts.Add(AddNewTextToUpperPanel());
            }

        }
    }
}
