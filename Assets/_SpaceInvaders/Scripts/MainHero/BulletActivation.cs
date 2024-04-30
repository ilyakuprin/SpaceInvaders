using System;
using _SpaceInvaders.Scripts.Bullet;
using UniRx;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class BulletActivation : IInitializable, IDisposable
    {
        private readonly Shooting _shooting;
        private readonly GameObject _bullet;
        private readonly CompositeDisposable _compositeDisposable = new();

        public BulletActivation(Shooting shooting,
                                BulletView bulletView)
        {
            _shooting = shooting;
            _bullet = bulletView.Rigidbody.gameObject;
        }

        public void Initialize()
            => _shooting.Shot.Subscribe(_ => Activate()).AddTo(_compositeDisposable);

        public void Dispose()
            => _compositeDisposable.Clear();
        
        private void Activate()
            => _bullet.SetActive(true);
    }
}