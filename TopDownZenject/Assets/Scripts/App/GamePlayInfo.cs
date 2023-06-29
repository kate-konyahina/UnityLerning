using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using System;

namespace TopDownZenject
{
    public class GamePlayInfo : IInitializable, ITickable
    {
        public int totalCoins;
        private GameController _gameController;
        GamePanel _gamePanel;

        public IReactiveProperty<int> collectedCoins { get; } = new IntReactiveProperty(0);
        public ReactiveProperty<int> BestCoins { get; } = new IntReactiveProperty(0);
        private const string BestCoinsKey = "Best.coins";


        [Inject]
        private void Construct(GameController gameController, GamePanel gamePanel)
        {
            _gameController = gameController;
            _gamePanel = gamePanel;
        }


        public void Initialize()
        {
            totalCoins = _gameController.numberOfCoins;
            BestCoins.Value = PlayerPrefs.GetInt(BestCoinsKey);
            BestCoins.Subscribe(_ => OnBestCoinsChange());
        }

        private void OnBestCoinsChange()
        {
            PlayerPrefs.SetInt(BestCoinsKey, BestCoins.Value);
            PlayerPrefs.Save();
        }

        public void Tick()
        {
            if (collectedCoins.Value == totalCoins)
            {
                _gamePanel.UpdateWinState();
            }
        }
    }
}
