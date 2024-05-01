using _SpaceInvaders.Scripts.MainHero.Bullet;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class MainHeroInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private MainHeroView _mainHeroView;
        [SerializeField] private MainHeroConfig _mainHeroConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            Container.Bind<MainHeroView>().FromInstance(_mainHeroView).AsSingle();
            Container.Bind<MainHeroConfig>().FromInstance(_mainHeroConfig).AsSingle();
            
            Container.BindInterfacesAndSelfTo<MainHeroMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<Shooting>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingStartPositionBullet>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletActivation>().AsSingle();
            Container.BindInterfacesAndSelfTo<DetectingBullet>().AsSingle();
        }
    }
}