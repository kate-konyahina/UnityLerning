using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace TopDownZenject
{
    public class GameController : IInitializable, IDisposable
    {
        private readonly ICharacterMove _character;
        private readonly InputHandler _inputHandler;
        private readonly EnemyFactory _enemyFactory;
        private readonly CoinFactory _coinFactory;
        public int numberOfCoins;     
    

        public GameController(ICharacterMove character, InputHandler inputHandler, EnemyFactory enemyFactory, CoinFactory coinFactory)
        {
            _character = character;
            _inputHandler = inputHandler;
            _enemyFactory = enemyFactory;
            _coinFactory = coinFactory;        
        }

        public void Initialize()
        {
            _inputHandler.OnClicked += OnClicked;
            _enemyFactory.Create(); 
            _enemyFactory.Create();
            
            numberOfCoins = UnityEngine.Random.Range(3, 10);
            for(int i = 0; i < numberOfCoins; i++)
            _coinFactory.Create();
        }

        private void OnClicked(Vector3 pos)
        {
            _character.MoveTo(pos);
        }

        public void Dispose()
        {
            _inputHandler.OnClicked -= OnClicked;
        }

    }
}
