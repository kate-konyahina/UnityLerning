using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownZenject
{
    public class Coin : MonoBehaviour
    {
        private GamePlayInfo _gamePlayInfo;

        [Inject]
        private void Construct(GamePlayInfo gamePlayInfo)
        {
            _gamePlayInfo = gamePlayInfo;
        }
        public void OnTriggerEnter(Collider collider)
        { 
            if (collider.gameObject.CompareTag("Player"))
            {
                _gamePlayInfo.collectedCoins.Value++;
                Destroy(gameObject);
            }
        }
    }
}
