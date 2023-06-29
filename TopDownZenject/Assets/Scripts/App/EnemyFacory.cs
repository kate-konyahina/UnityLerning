using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownZenject
{
    public class EnemyFactory
    {
        private readonly List<EnemyInfo> _enemyInfos;
        //private ICharacterMove _characterMove;
        private DiContainer _container;

        public EnemyFactory(DiContainer diContainer, List<EnemyInfo> enemyInfos)
        {
            _enemyInfos = enemyInfos;
            _container = diContainer;
        }

        public void Create()
        {   
            var enemyInfo = _enemyInfos[Random.Range(0,_enemyInfos.Count)];
            var enemyObject = Object.Instantiate(enemyInfo.Prefab);
            var enemy = enemyObject.GetComponent<Enemy>();
            enemyObject.transform.position = Random.insideUnitCircle * 10;
            enemy.Init(enemyInfo);
            _container.Inject(enemy);
            
        }
    }
}

