using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace TopDownZenject
{
    public class GamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI _coinCountLabel;
        [SerializeField] private GameObject _victoryPanel;
        [SerializeField] private TextMeshProUGUI _victoryLabel;
        [SerializeField] private GameObject _defeatPanel;
        [SerializeField] private TextMeshProUGUI _defeatLabel;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private TextMeshProUGUI _restartButtonText;
        [SerializeField] private TextMeshProUGUI _bestScore;
        [SerializeField] private GameObject _exitButton;
        [SerializeField] private TextMeshProUGUI _exitButtonText;

        private GamePlayInfo _gamePlayInfo;
        private GameController _gameController;
        private ILocalization _localization;

        [Inject]
        private void Construct(GamePlayInfo gamePlayInfo, ILocalization localization, GameController gameController)
        {
            _localization = localization;
            _gamePlayInfo = gamePlayInfo;
            _gameController = gameController;
        }

        public void Initialize()
        {
            AddListeners();
           _coinCountLabel.text = _localization.Translate("coins.Count") + _gamePlayInfo.collectedCoins + "/" + _gameController.numberOfCoins;
        }

        private void AddListeners()
        {
            _gamePlayInfo.collectedCoins.Subscribe(value => UpdateInfo(value));
            _gamePlayInfo.BestCoins.Subscribe(value => UpdateBest(value));
        }

        private void UpdateBest(int value)
        {
            _bestScore.text = _localization.Translate("coins.Best") + value;
        }

        private void UpdateInfo(int value)
        {
            _coinCountLabel.text = _localization.Translate("coins.Count") + value + "/" + _gameController.numberOfCoins;
        }

        public void UpdateDefeatState()
        {

            if (_gamePlayInfo.BestCoins.Value < _gamePlayInfo.collectedCoins.Value)
            {
                _gamePlayInfo.BestCoins.Value = _gamePlayInfo.collectedCoins.Value;
            }
            _defeatPanel.SetActive(true);
            _defeatLabel.text = _localization.Translate("state.Lose");
            _restartButton.SetActive(true);
            _restartButtonText.text = _localization.Translate("button.TryAgain");
            _exitButton.SetActive(true);
            _exitButtonText.text = _localization.Translate("button.Exit");

            Time.timeScale = 0f;
        }

        public void UpdateWinState()
        {
            _victoryPanel.SetActive(true);
            _victoryLabel.text = _localization.Translate("state.Win");
            _restartButton.SetActive(true);
            _restartButtonText.text = _localization.Translate("button.TryAgain");
            _exitButton.SetActive(true);
            _exitButtonText.text = _localization.Translate("button.Exit");

            Time.timeScale = 0f;
        }

        public void LoadScene(int sceneid)
        {
            SceneManager.LoadScene(sceneid);
            Time.timeScale = 1f;
        }
    }
}
