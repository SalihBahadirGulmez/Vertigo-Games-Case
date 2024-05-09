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


        [SerializeField] private UpperPanleTextData _upperPanelTextData;
        [SerializeField] private GameControllerData _gameControllerData;
        [SerializeField] private List<GameObject> _upperPanelTextGameObjects = new List<GameObject>();

        [SerializeField] private GameObject _upperPanelTextPrefab;
        [SerializeField] private Transform _upperPanelRoundInfo;
        [SerializeField] private Transform _upperPanelPosition;
        [SerializeField] private Image _currentRoundBgImage;

        public void PrepareUpperPanelForNextRound()
        {

            if (_upperPanelTextGameObjects.Count >= _upperPanelTextData.MaxTextCount)
            {
                Destroy(_upperPanelTextGameObjects[_upperPanelTextGameObjects.Count - _upperPanelTextData.MaxTextCount]);
                _upperPanelMovementController.AdjustPanelPosition();
            }
            _upperPanelTextGameObjects.Add(AddNewTextToUpperPanel());
            AdjustCurrentRoundTextAndImage();
        }

        public GameObject AddNewTextToUpperPanel()
        {
            GameObject newGameObj = Instantiate(_upperPanelTextPrefab, _upperPanelRoundInfo);
            TextMeshProUGUI tempText = newGameObj.GetComponent<TextMeshProUGUI>();
            UpperPanelTextAdjustmen(tempText);
            return newGameObj;
        }

        public void UpperPanelTextAdjustmen(TextMeshProUGUI text)
        {
            if ((_upperPanelTextGameObjects.Count + 1) % 30 == 0)
            {
                text.color = Color.yellow;
                text.fontStyle = FontStyles.Bold;
            }
            else if ((_upperPanelTextGameObjects.Count + 1) % 5 == 0)
            {
                text.color = new Color(0.48f, 0.804f, 0.12f, 1);
                text.fontStyle = FontStyles.Bold;
            }
            else
            {
                text.color = Color.white;
            }
            text.text = (_upperPanelTextGameObjects.Count + 1).ToString();
        }

        public void AdjustCurrentRoundTextAndImage()
        {
            if (_gameControllerData.CurrentRound % 30 == 0)
            {
                _upperPanelTextGameObjects[_gameControllerData.CurrentRound - 1].GetComponent<TextMeshProUGUI>().color = Color.white;
                _currentRoundBgImage.sprite = _upperPanelTextData.CurrentRoundBgSpriteAtlas.GetSprite(_upperPanelTextData._spriteAtlasNames[2]);
            }
            else if (_gameControllerData.CurrentRound % 5 == 0)
            {
                _upperPanelTextGameObjects[_gameControllerData.CurrentRound - 1].GetComponent<TextMeshProUGUI>().color = Color.white;
                _currentRoundBgImage.sprite = _upperPanelTextData.CurrentRoundBgSpriteAtlas.GetSprite(_upperPanelTextData._spriteAtlasNames[1]);
            }
            else
            {
                _upperPanelTextGameObjects[_gameControllerData.CurrentRound - 1].GetComponent<TextMeshProUGUI>().color = Color.white;
                _currentRoundBgImage.sprite = _upperPanelTextData.CurrentRoundBgSpriteAtlas.GetSprite(_upperPanelTextData._spriteAtlasNames[0]);
            }
            
            if(_gameControllerData.CurrentRound - 1 > 0 && (_gameControllerData.CurrentRound - 1) % 30 == 0)
            {
                _upperPanelTextGameObjects[_gameControllerData.CurrentRound - 2].GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            else if (_gameControllerData.CurrentRound - 1 > 0 && (_gameControllerData.CurrentRound - 1) % 5 == 0)
            {
                _upperPanelTextGameObjects[_gameControllerData.CurrentRound - 2].GetComponent<TextMeshProUGUI>().color = new Color(0.48f, 0.804f, 0.12f, 1);
            }
        }

        public void PrepareUpperPanelForNewGame()
        {
            for (int i = 0; i < _upperPanelTextGameObjects.Count; i++)
            {
                Destroy(_upperPanelTextGameObjects[i]);
            }
            _upperPanelTextGameObjects.Clear();

            _upperPanelRoundInfo.position = _upperPanelPosition.position;

            for (int i = 0; i < _upperPanelTextData.InitialTextCount; i++)
            {
                _upperPanelTextGameObjects.Add(AddNewTextToUpperPanel());
            }

        }
    }
}
