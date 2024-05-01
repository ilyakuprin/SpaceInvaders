using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.Bullet
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private BulletView _bulletView;
        [SerializeField] private BulletConfig _bulletConfig;

        public override void InstallBindings()
        {
            Container.Bind<BulletView>().FromInstance(_bulletView).AsSingle();
            Container.Bind<BulletConfig>().FromInstance(_bulletConfig).AsSingle();
            
            Container.BindInterfacesAndSelfTo<MovementBullet>().AsSingle();
            Container.BindInterfacesAndSelfTo<HidingBullet>().AsSingle();
            Container.BindInterfacesAndSelfTo<DetectingEnemy>().AsSingle();
        }
    }
}