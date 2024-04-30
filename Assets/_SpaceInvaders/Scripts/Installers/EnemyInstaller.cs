using _SpaceInvaders.Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyView>().FromInstance(_enemyView).AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<Movement>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingDirection>().AsSingle();
        }
    }
}