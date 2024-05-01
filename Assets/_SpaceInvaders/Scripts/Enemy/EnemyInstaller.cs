using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Enemy
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyView>().FromInstance(_enemyView).AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<CreatingEnemy>().AsSingle();
            Container.BindInterfacesAndSelfTo<HorizontalMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<DetectingWall>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementDown>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingDirection>().AsSingle();
            Container.BindInterfacesAndSelfTo<DetectingBottom>().AsSingle();
            Container.BindInterfacesAndSelfTo<HidingEnemy>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyCounter>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<SearchingShootingEnemies>().AsSingle();
            Container.BindInterfacesAndSelfTo<Shooting>().AsSingle();
        }
    }
}