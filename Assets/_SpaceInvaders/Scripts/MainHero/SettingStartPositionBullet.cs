using System;
using _SpaceInvaders.Scripts.Bullet;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class SettingStartPositionBullet : IInitializable, IDisposable
    {
        private readonly Transform _bullet;
        private readonly Transform _firePoint;
        private readonly Shooting _shooting;
        private readonly CompositeDisposable _compositeDisposable = new();

        public SettingStartPositionBullet(BulletView bulletView,
                                          MainHeroView mainHeroView,
                                          Shooting shooting)
        {
            _bullet = bulletView.Rigidbody.transform;
            _firePoint = mainHeroView.FirePoint;
            _shooting = shooting;
        }

        public void Initialize()
            => _shooting.Shot.Subscribe(_ => Set()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
        
        private void Set()
            => _bullet.position = _firePoint.position;
    }
}