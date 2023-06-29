using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownZenject
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private Camera _camera;
        //[SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private GamePanel _gamePanel;
        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
            Container.Bind<ICharacterMove>().FromComponentInNewPrefab(_characterPrefab).AsSingle();
            Container.Bind<Camera>().WithId(BaseIds.GameCameraId).FromInstance(_camera);
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
            Container.Bind<EnemyFactory>().AsSingle().NonLazy();
            Container.BindFactory<Coin, CoinFactory>().FromComponentInNewPrefab(_coinPrefab);
            Container.BindInterfacesAndSelfTo<GamePanel>().FromInstance(_gamePanel);
            Container.Bind<ILocalization>().To<UnityLocalization>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GamePlayInfo>().AsSingle().NonLazy();
            foreach(var enemyInfo in _enemyInfos)
            {
                Container.Bind<EnemyInfo>().FromInstance(enemyInfo);
            }
        }
     }
}
